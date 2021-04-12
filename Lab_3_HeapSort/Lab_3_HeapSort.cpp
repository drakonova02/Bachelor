#include <iostream>

using namespace std;

class List {

public:
	List(int = 10);
	~List();
	bool isFull();
	bool isEmpty();
	int length(); //The number of list items is returned.
	void makeEmpty();
	void addItem(int item); //It inserts an item at the list end.
	int deleteItem(int item); //It deletes and returns an item.
	void printList();
	void HeapSort();

protected:
	int max; //array size
	int last; //index of the last list item
	//Note: element[0] is not used.
	int* arr; //pointer to the first element of a dynamic array
	int search(int item); //search item in array.
	void swap(int index1, int index2);
	void settleRoot_asc(int root, int last); //used in heapSort for ascending order
	void settleRoot_des(int root, int last); //used in heapSort for descending order
};

//constructor List
List::List(int n) {
	max = n + 1; //max number of element + arr[0] isn`t used
	last = 0;
	arr = new int[max]; // create dynamic array
}

//destructor List
List::~List() {
	delete []arr;
	last = 0;
}

//Create metods of class List
bool List::isFull() {
	return (last == max - 1);
}

bool List::isEmpty() {
	return(last == 0);
}

int List::length() {
	return last;
}

void List::makeEmpty(){
	last = 0;
}

void List::addItem(int item) {
	if (!(isFull())) {
		cout << "List overflow: item cannot be added.\n";
			return;
	}
	arr[++last] = item;
}

int List::search(int item) {
	for (int i = 1; i <= last; ++i) if (item == arr[i]) return i;
	return -1;
}

int List::deleteItem(int item) {
	if (isEmpty()) {
		cout << "List is empty: item cannot be deleted.\n";
		return;
	}
	if (search(item) == -1) {
		cout << "Item isn`t in List.\n";
		return;
	}
	int index = search(item);
	while (index != -1) {
		int temp = arr[index];
		arr[index] = arr[last--];
		index = search(item);
	}
	return item;
}

void List::printList() {
	if (isEmpty) {
		cout << "List is Empty.\n";
		return;
	}
	for (int i = 1; i <= last; ++i) cout << arr[i] << " ";
	cout << endl;
}

void List::swap(int index1, int index2) {
	int temp = arr[index1];
	arr[index1] = arr[index2];
	arr[index2] = temp;
}

void List::HeapSort(){	
	cout << "Do you want to sort List in ascending or descending orders?\nIf in ascending order - input '1', else '0'\n\n";
	int order;
	cin >> order;
	if (order == 1) {
		for (int i = last / 2; i >= 1; --i)		// heap construction loop
			settleRoot_asc(i, last);
		for (int end = last - 1; end >= 1; --end)	// actual sorting loop
		{
			swap(1, end + 1);
			settleRoot_asc(1, end);
		}
	}
	else {
		for (int i = last / 2; i >= 1; --i)		// heap construction loop
			settleRoot_des(i, last);
		for (int end = last - 1; end >= 1; --end)	// actual sorting loop
		{
			swap(1, end + 1);
			settleRoot_des(1, end);
		}
	}
}


void List::HeapSort() {
	
}

void main()
{
   
}