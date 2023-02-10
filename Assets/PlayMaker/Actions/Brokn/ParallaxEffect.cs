using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Brokn")]
	public class ParallaxEffect : FsmStateAction
	{

		public FsmOwnerDefault gameObject;
		public FsmFloat ParallaxAmount;

		private float StartPos, Length;


	
		public override void OnEnter()
		{
			StartPos = Fsm.GetOwnerDefaultTarget(gameObject).transform.position.x;
			Length = Fsm.GetOwnerDefaultTarget(gameObject).GetComponent<SpriteRenderer>().bounds.size.x;
		}
        public override void OnUpdate()
        {
			float temp = (Camera.main.transform.position.x * (1 - ParallaxAmount.Value));
			float dist = (Camera.main.transform.position.x * ParallaxAmount.Value);
			Fsm.GetOwnerDefaultTarget(gameObject).transform.position = new Vector3(StartPos + dist, Fsm.GetOwnerDefaultTarget(gameObject).transform.position.y, Fsm.GetOwnerDefaultTarget(gameObject).transform.position.z);
			if(temp > StartPos + Length) { StartPos += Length; }
			else if (temp < StartPos - Length) { StartPos -= Length; }

           

		}

    }

}
