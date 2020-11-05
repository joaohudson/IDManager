class IDManager{

	private int[] ids;
	private bool[] enables;
	private int count;
	private int it;

	public IDManager(int size){
		ids = new int[size];
		enables = new bool[size];

		for(int i = 0; i < size; i++){
			ids[i] = i;
		}
	}

	/// <summary>
	/// Informa se existe um próximo ID.
	/// </summary>
	public bool HasNext(){
		return it < count;
	}
		
	/// <summary>
	/// Obtém o próximo ID. Você
	/// deve chamar HasNext antes!
	/// </summary>
	public int Next(){
		return ids[it++];
	}

	/// <summary>
	/// Reinicia a iteração e destrói
	/// os IDs marcados por Delete.
	/// </summary>
	public void Reset(){
		int aux;
		it = 0;

		for(int i = 0; i < count;){
			if(!enables[ids[i]]){
				aux = ids[i];
				ids[i] = ids[count - 1];
				ids[count - 1] = aux;
				count--;
			}
			else{
				i++;
			}
		}
	}

	/// <summary>
	/// Cria um novo ID que será incluído
	/// ainda nessa iteração.
	/// </summary>
	public int New(){
		if(count == ids.Length)
			return -1;

		int id = ids[count++];
		enables[id] = true;
		return id;
	}

	/// <summary>
	/// Marca um ID para ser deletado,
	/// ele só será deletado no fim da
	/// iteração ao chamar Reset.
	/// </summary>
	/// <param name="id">ID a ser deletado.</param>
	public void Delete(int id){
		enables[id] = false;
	}

	/// <summary>
	/// Se o ID foi marcado para ser deletado.
	/// </summary>
	/// <param name="id">ID a ser verificado.</param>
	public bool IsValid(int id){
		return enables[id];
	}

	/// <summary>
	/// Capacidade máxima desse gerenciador.
	/// </summary>
	public int Capacity{
		get{
			return ids.Length;
		}
	}
}
