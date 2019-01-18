using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseComplete : MonoBehaviour{
	
	public void Fulfill (Product product){
		
		if (product != null) {
			
			switch (product.definition.id){
			case "100.gold.coins":
				Debug.Log ("You Got Money!");
				break;
			default:
				Debug.Log (
					string.Format ("Unrecognized productId \"{0}\"",product.definition.id)
				);
				break;
			}
		}
	}
}