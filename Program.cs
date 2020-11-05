using System;
using System.Collections.Generic;

public class main{
	///Teste da classe IDManager, para gerenciar IDs e controlar
	///alocação de recursos indexados, evitando alocação de memória com new.
	
	///É possível iterar, alocar e deletar IDs
	///com IDManager, incluindo deletar e adicionar
	///IDs durante a iteração, mas os que forem deletados
	///só serão de fato deletados ao fim da iteração.
	///O custo das operações são O(1), exceto Reset que é O(n).
	
	static void Main(string[] args){
		const int size = 10;
		Counter[] counters = new Counter[size];
		IDManager idManager = new IDManager(size);
		
		for(int i = 0; i < counters.Length; i++){//inicializa o array
			counters[i] = new Counter();
			counters[i].Init(i + 1);
		}
		
		for(int i = 0; i < counters.Length; i++){//aloca o máximo de IDs
			idManager.New();
		}
		
    Console.WriteLine("--------------------");
		while(idManager.HasNext()){
			int id = idManager.Next();
			int step = counters[id].Step();
			Console.WriteLine("ID: {0:D} Step: {0:D}", id, step);
			if(counters[id].Finished)
				idManager.Delete(id);//remove o contador corrente.
		}
		idManager.Reset();
		
		//aloca 2 novos IDs(contadores)
		idManager.New();
		int invalid = idManager.New();//tenta alocar além do limite
    Console.WriteLine("[Overflow, invalid ID: {0:D}]", invalid);
		
    Console.WriteLine("--------------------");
		while(idManager.HasNext()){
			int id = idManager.Next();
			int step = counters[id].Step();
			Console.WriteLine("ID: {0:D} Step: {0:D}", id, step);
			if(counters[id].Finished)
				idManager.Delete(id);//remove o contador corrente.
		}
		idManager.Reset();
	}
}