#include <iostream>
#include<string>

using namespace std;

template <typename T>
struct Node {
	//data members
	T data;
	Node<T>* next;
	// constructors
	Node();
	Node(T d, Node<T>* link = NULL);
};

template <typename T>
class List {
public:    // methods of the List ADT
	List(int = 10);	//default constructor
	~List();	//destructor
	bool isFull();
	bool isEmpty();
	int listSize();
	void printList();
	void addItem(T item);
	string deleteItem(string item);
	int deleteItem(int item);
	void makeEmpty();
	bool search(T item);
	string retrieve(string item);
	int retrieve(int item);
private:     // data members for linked list implementation
	int count;
	int max; //max number of nodes
	Node<T>* first;
};//List

template <typename T>
Node<T>::Node() {
	next = NULL;
}	//constructor for an empty node

template <typename T>
Node<T>::Node(T item, Node<T>* link) {
	data = item;
	next = link;
}	//node constructor with initial values

template <typename T>
List<T>::List(int n) {
	max = n;
	count = 0;
	first = NULL;
}//empty

template <typename T>
List<T>::~List() {
	makeEmpty();
}//~List

template <typename T>
bool List<T>::isEmpty() {
	return count == 0; // return first == NULL;	}//empty
}

template <typename T>
int List<T>::listSize() {
	return count;
}//listSize

template <typename T>
bool List<T>::isFull() {
	bool result = false;
	Node<T>* temp;
	temp = new Node <T>();
	if (temp == NULL) {
		delete temp;
		return true;
	}
	else if (max < count + 1) return true;
	else return false;
}//isFull

template <typename T>
void List<T>::addItem(T item) {
	if (isFull()) {
		cout << "List overflow\n";
		return; //return to the calling function
	}
	else {
		Node<T>* previous = NULL, * following = first;
		while (following != NULL && following->data < item)
		{
			previous = following;
			following = following->next;
		}//while
		if (previous == NULL) first = new Node<T>(item, first);
		else previous->next = new Node<T>(item, following);
		count += 1;
	}
}//addItem

template <typename T>
void List<T>::printList() {
	cout << "\n\nList content:\n";
	if (count == 0) cout << "list is empty.\n";
	Node<T>* p = first;
	while (p != NULL) {
		cout << p->data << ", ";
		p = p->next;
	}//while
	cout << endl;
}//printList

template <>
string List<string>::deleteItem(string item) {
	string result = "";
	if (isEmpty()) {
		cout << "List underflow\n";
		return "-10000";
	}
	Node<string>* previous = NULL, * following = first;
	while (following != NULL && following->data != item)           //searching for item
	{
		previous = following;
		following = following->next;
	}//while
	//deleting 1st node
	if (following == NULL) {
		cout << "Item was not found and not deleted\n";
		return "-10000";
	}
	while (following != NULL) {
		previous = NULL;
		following = first;
		while (following != NULL && following->data != item)           //searching for item
		{
			previous = following;
			following = following->next;
		}//while
		if (previous == NULL && following != NULL && following->data == item)
		{
			result = following->data;
			first = first->next;
			count--;
		}
		else if (previous != NULL && following != NULL && following->data == item)
		{
			result = following->data;		               //deleting not 1st  node.
			previous->next = following->next;
			count--;
		}
		if (following == NULL) break;
	}
	return item;
}

template <>
int List<int>::deleteItem(int item) {
	int result = 0;
	if (isEmpty()) {
		cout << "List underflow\n";
		return -10000;
	}
	Node<int>* previous = NULL, * following = first;
	while (following != NULL && following->data != item)           //searching for item
	{
		previous = following;
		following = following->next;
	}//while
	//deleting 1st node
	if (following == NULL) {
		cout << "Item was not found and not deleted\n";
		return -10000;
	}
	while (following != NULL) {
		previous = NULL;
		following = first;
		while (following != NULL && following->data != item)           //searching for item
		{
			previous = following;
			following = following->next;
		}//while
		if (previous == NULL && following != NULL && following->data == item)
		{
			result = following->data;
			first = first->next;
			count--;
		}
		else if (previous != NULL && following != NULL && following->data == item)
		{
			result = following->data;		               //deleting not 1st  node.
			previous->next = following->next;
			count--;
		}
		if (following == NULL) break;
	}
	return item;
}

template <typename T>
void List<T>::makeEmpty() {
	count = 0;
	Node<T>* temp;
	while (first != NULL) {
		temp = first;
		first = first->next;
		delete temp;
	}
}//makeEmpty

template <typename T>
bool List<T>::search(T item) {
	Node<T>* p = first;
	while (p != NULL)
	{
		if (p->data == item) return true;
		else p = p->next;
	}//while
	return false;
}//search

template <>
string List<string>::retrieve(string item) {
	Node<string>* p = first;
	while (p != NULL) {
		if (p->data == item) return p->data;
		else p = p->next;
	}//while
	cout << "item was not found, was not retrieved\n";
	return "-10000"; //to signal not found	
}//retrieve

template <>
int List<int>::retrieve(int item) {
	Node<int>* p = first;
	while (p != NULL) {
		if (p->data == item) return p->data;
		else p = p->next;
	}//while
	cout << "item was not found, was not retrieved\n";
	return -10000; //to signal not found	
}//retrieve

void main()
{
	int a;
	cout << "Write max number for nodes: ";
	cin >> a;
	List <string> A(a); //object A of class List with int items Note
	A.addItem("bet");
	A.addItem("ann");
	A.addItem("vanda");
	A.addItem("sara");
	A.addItem("archi");
	A.printList();
}
