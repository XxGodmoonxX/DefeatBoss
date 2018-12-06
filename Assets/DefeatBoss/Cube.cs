using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI; //これでText使える

namespace UnityEngine.XR.iOS
{
	public class Cube : MonoBehaviour
	{
		public Camera cam;

		// public Transform m_HitTransform;
		// public float maxRayDistance = 30.0f;
		// public LayerMask collisionLayer = 1 << 10;  //ARKitPlane layer

		void Start () {

		}

		// Update is called once per frame
		void Update () {
				// Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				// RaycastHit hit;

				// if (Physics.Raycast (ray, out hit, maxRayDistance, collisionLayer)) {
				// 	//we're going to get the position from the contact point
				// 	m_HitTransform.position = hit.point;
				// 	Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));

				// 	//and the rotation from the transform of the plane collider
				// 	m_HitTransform.rotation = hit.transform.rotation;
				// }
				// var touch = Input.GetTouch(0);
				// var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
				// ARPoint point = new ARPoint {
				// 	x = screenPosition.x,
				// 	y = screenPosition.y
				// };

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				//Cubeに適用するランダムな色を生成する
                Material material = new Material(Shader.Find("Diffuse")) {
                    // color = new Color(Random.value, Random.value, Random.value)
					color = new Color(0, 0, 200)
                };
                //ランダムに変化する色をCubeに適用する
                cube.GetComponent<Renderer>().material = material;

                //端末をタップして、ランダムな色のCubeを認識した平面上に投げ出すように追加していく
                cube.transform.position = cam.transform.TransformPoint(0, 0, 0.5f);
				// cube.transform.position = cam.transform.TransformPoint(0.5f, 0, 0);

                //Cubeの大きさも0.2fとして指定している
                cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                //CubeにはRigidbodyを持たせて重力を与えておかないと、床の上には配置されないので注意が必要。Rigidbodyで重力を持たせないとCubeは宙に浮いた状態になる
                cube.AddComponent<Rigidbody>();
				//これでタップしたときに斜め上にキューブ飛んでいく？そして衝突計算
                // cube.GetComponent<Rigidbody>().AddForce(cam.transform.TransformDirection(0,1f,2f),ForceMode.Impulse);
				// cube.GetComponent<Rigidbody>().AddForce(cam.transform.TransformDirection(0, 2f, 0),ForceMode.Impulse);
				cube.GetComponent<Rigidbody>().AddForce(cam.transform.TransformDirection(0, 0, 3f),ForceMode.Force);

		}
	}
}

