using System;
using UnityEngine;
namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankController : Tank
    {

        private Rigidbody tourrer;

        private GameObject cameraObject;
        [SerializeField]
        private Rigidbody rbTank = null;

        private ShootAction EventShootAction;

        public DeadAction EventDeadAction;

        private float rotateSpeed;


        private void Start()
        {
            tourrer = SpawnModulePos.GetComponent<Rigidbody>();
            cameraObject = GameObject.FindWithTag("MainCamera");
            cameraObject.GetComponent<SImple_Camera>().InitCamera(SpawnModulePos.gameObject);
            cameraObject.transform.SetParent(SpawnModulePos);

            GetComponentInChildren<MeshRenderer>().material.color = TankColor;

        }

        private void FixedUpdate()
        {
            PlayerTankMoving();
            ObservingFoHP();
        }

        private void Update()
        {
            PlayerTankShoting();
            PlayerTankChooseShellType();
        }

        #region PlayerHaracterisicObservingRegion
        private void ObservingFoHP()
        {
            if (tankParams.CurrentHPValue() < 0)
            {
                EventDeadAction();
            }
        }
        #endregion

        #region PlayerMoveningRegion
        private void PlayerTankMoving()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            float mouseXpos = Input.mousePosition.x;
            float mouseYpos = Input.mousePosition.y;

            Vector3 movement;
            Quaternion rotation;
            movement = new Vector3(0f, 0.0f, moveVertical) * TankSpeed ;

            if (movement.z >= 0)
            {
                rotateSpeed += moveHorizontal * TankSpeed * 10f * Time.fixedDeltaTime;
                rotation = Quaternion.Euler(new Vector3(0f, rotateSpeed, 0f));
            }
            else
            {
                rotateSpeed += -moveHorizontal * TankSpeed * 10f * Time.fixedDeltaTime;
                rotation = Quaternion.Euler(new Vector3(0f, rotateSpeed, 0f));
            }
            rbTank.rotation = rotation;
            var angle = rotation.eulerAngles;



            rbTank.velocity = Quaternion.AngleAxis(angle.y, Vector3.up) * movement;



            Vector3 rotateTourrer = new Vector3(0, mouseXpos * TankSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(TankSpeed * rotateTourrer * Time.fixedDeltaTime);
            tourrer.rotation = deltaRotation;


        }

        #endregion

        #region ShootActionRegion
        private void PlayerTankShoting()
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.X))
            {
                EventShootAction((int)currentShellType);
            }
        }

        #endregion

        private void PlayerTankChooseShellType()
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                if (currentShellType > 0)
                {
                    currentShellType--;
                }
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                if ((int)currentShellType < GunModule.Shells.Length - 1)
                {
                    currentShellType++;
                }
            }
        }



        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Enemy")
            {
                tankParams.TakeDamage(CollisionAttack);
            }
        }

        private void OnEnable()
        {
            EventShootAction += MakeShoot;
            EventDeadAction += ReSpawnTank;
        }

        private void OnDisable()
        {
            EventShootAction -= MakeShoot;
            EventDeadAction -= ReSpawnTank;
        }
    }
}
