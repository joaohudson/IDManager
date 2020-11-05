public class Counter{
	private int count;
	
	public void Init(int count){
		this.count = count;
	}
	
	public int Step(){
		return count--;
	}
	
	public bool Finished{
		get{return count <= 0;}
	}
}