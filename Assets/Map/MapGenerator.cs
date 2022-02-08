/*

Simple guidelines:
https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/





*/
public class MapGenerator : MonoBehaviour {
  
    [SerializeField]
    public Builder builder; 
  
    [SerializeField]
    public Template template; 



    public void GenerateMap() {
        foreach (var block in this.template.getTemplateBlocks()) {
            
        }

    }

}