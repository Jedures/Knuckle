using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Basic Controll")]
    public float MoveSpeed = 5f;
	public float MoveSpeedBoost = 15f;
	public float MoveSpeedDefault = 5f;
    public float Drag = 0.5f;

	public float speed_rotation = 0.1f;

    public Vector3 MoveVector { get; set; }

    public JoystickController joystick;

    private Rigidbody2D rigidBody;
	[Header("Scores")]
	public int score = 0;
	public float boostTime = 100;
    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.drag = Drag;
    }

    private void FixedUpdate()
    {

		Vector3 position = new Vector3(PoolInput().x, PoolInput().y, 0f);
        MoveVector = PoolInput();
        rigidBody.AddForce((MoveVector * MoveSpeed));
		transform.up = Vector3.Lerp(transform.up, position.normalized, speed_rotation);
		Boost ();
    }

    private Vector3 PoolInput()
    {
        Vector3 result = Vector3.zero;

        result.x = joystick.GetHorizontal();
        result.y = joystick.GetVertical();

        if (result.magnitude > 1)
            result.Normalize();

        return result;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.collider.CompareTag ("Weapon")) {
			Death ();
		} else if (collision.collider.CompareTag ("Score")) {
			score += 5;
		} else if (collision.collider.CompareTag ("Score2")) {
			score += 10;
		}

    }

    private void Death()
    {
        // death handle
        Loading.Load(LoadingScene.Menu);
    }

	private void Boost()
	{
		bool isBoost = false;
		if (Input.touchCount > 15 || Input.GetMouseButton (0)) {
			isBoost = true;
		} else
			isBoost = false;
		if (isBoost == true && boostTime > 0) {
			MoveSpeed = MoveSpeedBoost;
			boostTime -= Time.deltaTime * 200;
			if (boostTime <= 0) {
				boostTime = 0;
				MoveSpeed = MoveSpeedDefault;
			}
		} 
		else {
			MoveSpeed = MoveSpeedDefault;

			if (boostTime < 0)
				boostTime = 0;
			if (boostTime > 100)
				boostTime = 100;
			if (boostTime < 100 )
				boostTime += Time.deltaTime * 200;
		}
	}
}
