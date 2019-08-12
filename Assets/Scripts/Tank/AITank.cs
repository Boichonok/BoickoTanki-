
using UnityEngine;
using System.Collections;
namespace Tank
{
    public class AITank : Tank
    {
        [SerializeField]
        private float shotDistance = 15.0f;


        private float delayShoting = 40.0f;

        [SerializeField]
        private float resetDelayShoting = 40.0f;

        private GameObject[] wayPoints;

        [SerializeField]
        private GameObject currentWayPoint;

        private GameObject playerTank;

        private GameObject lastWayPoint;

        private bool canMove = true;
        private bool stoped = false;

        private float time_ = 2f;

        private RaycastHit rayHit;

        private RaycastHit rayHit1;

        private Vector3 bufModulePos;

        private ShootAction EventShootAITankAction;
        public DeadAction EventDeadAction;

        private void Start()
        {
            GetComponentInChildren<MeshRenderer>().material.color = TankColor;
            playerTank = GameObject.FindWithTag("Player");

            wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
            currentWayPoint = wayPoints[Random.Range(0, wayPoints.Length - 1)];
            bufModulePos = Vector3.zero;
        }

        private void Update()
        {
            ObservingAITankStates();
            ObservingFoHP();
        }

        #region AI
        private void ObservingFoHP()
        {
            if (tankParams.CurrentHPValue() < 0)
            {
                EventDeadAction();
            }
        }

        private void ObservingAITankStates()
        {

            if (Vector3.Distance(playerTank.transform.position, this.transform.position) < shotDistance * 2.0f)
            {
                var isRideFinished = RideToPoint(playerTank.transform.position, 0.9f, rayHit, 7, 6, 6, rayHit1, shotDistance);
                if (isRideFinished)
                {
                    EventShootAITankAction((int)currentShellType);

                }
            }
            else
            {
                if (currentWayPoint == lastWayPoint)
                    currentWayPoint = wayPoints[Random.Range(0, wayPoints.Length - 1)];
                var isRide = RideToPoint(currentWayPoint.transform.position, 0.9f, rayHit, 7, 6, 6, rayHit1, 5.0f);
                if (isRide)
                {
                    lastWayPoint = currentWayPoint;
                }

            }
        }

        bool RideToPoint(Vector3 pointInFront,
                         float betweanRay,
                         RaycastHit hit,
                         float centralRayLength,
                         float leftRayLength,
                        float rightRayLength,
                         RaycastHit hit1,
                         float finishedDistance)
        {

            if (canMove)
            {
                var directionToPoint = (pointInFront - this.transform.position);//.normalized;
                var directionToPointNormalaized = directionToPoint.normalized;
                Vector3 centralRay = transform.position + (transform.right * betweanRay / 10);
                Vector3 leftRay = transform.position - (transform.right * betweanRay);
                Vector3 rightRay = transform.position + (transform.right * betweanRay);


                directionToPointNormalaized.y = 0;

                if (Physics.Raycast(centralRay, transform.forward, out hit, centralRayLength))
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    directionToPointNormalaized += hit.normal * 3;
                }

                if (Physics.Raycast(leftRay, transform.forward, out hit, leftRayLength))
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    directionToPointNormalaized += hit.normal * 3;
                }

                if (Physics.Raycast(rightRay, transform.forward, out hit, rightRayLength))
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    directionToPointNormalaized += hit.normal * 3;
                }
                else
                {
                    Debug.DrawRay(centralRay, transform.forward * centralRayLength, Color.yellow);
                    Debug.DrawRay(leftRay, transform.forward * leftRayLength, Color.yellow);
                    Debug.DrawRay(rightRay, transform.forward * rightRayLength, Color.yellow);

                }

                var lookRotation = Quaternion.LookRotation(directionToPointNormalaized);

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, TankSpeed * Time.deltaTime);

                var rotationTower = Quaternion.Slerp(GunModule.Tower.transform.rotation, lookRotation, TankSpeed * Time.deltaTime);
                GunModule.Tower.transform.rotation = rotationTower;
                GunModule.Tower.transform.localPosition = bufModulePos;
                if (directionToPoint.magnitude > finishedDistance)
                {
                    this.transform.Translate(0, 0, TankSpeed * Time.deltaTime);
                }
                else
                {
                    return true;
                }

                if (Physics.Raycast(leftRay, transform.forward, out hit, leftRayLength)
                   && Physics.Raycast(rightRay, transform.forward, out hit, rightRayLength))
                {
                    time_ -= Time.deltaTime;
                    if (time_ < 0)
                    {
                        canMove = false;
                        stoped = true;
                        time_ = 1f;
                    }
                }
                else
                {
                    time_ = 2f;
                }

            }
            if (stoped)
            {
                time_ -= Time.deltaTime;
                var lastRotation = transform.rotation.y;
                if (time_ > 0)
                {
                    this.transform.Rotate(0, 3, 0);
                }
                var directionToPointNormalaized = (pointInFront - this.transform.position).normalized;
                Ray ray = new Ray(transform.position, directionToPointNormalaized);
                if (Physics.Raycast(ray, out hit1))
                {
                    if (hit1.collider.tag == "Player")
                    {
                        canMove = true;
                        stoped = false;
                    }
                }

            }
            return false;
        }


        private void Shoot(int currentShell)
        {

            delayShoting -= 1 + Time.fixedDeltaTime;
            if (delayShoting < 0.0f)
            {
                delayShoting = resetDelayShoting;
                currentShellType = GunModule.Shells[Random.Range(0, 2)].GetComponent<Shell>().ShellType;
                MakeShoot(currentShell);
            }
        }
        #endregion

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                tankParams.TakeDamage(CollisionAttack);
            }
        }

        void OnEnable()
        {
            EventShootAITankAction += Shoot;
            EventDeadAction += ReSpawnTank;
        }

        private void OnDisable()
        {
            EventShootAITankAction -= Shoot;
            EventDeadAction -= ReSpawnTank;
        }


    }


}
