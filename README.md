IDManager class, manager the index allocation with cost:
New: O(1)
Delete: O(1)
HasNext: O(1)
Next: O(1)
IsValid: O(1)
Rest: O(n)

Default use:

while(idManager.HasNext()){
	idManager.Next();//use the value returned here
}
idManager.Reset();//iteration end