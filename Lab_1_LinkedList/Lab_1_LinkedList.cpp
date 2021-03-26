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

void main()
{
	int a;
	cout << "Write max number for nodes: ";
	cin >> a;
	List <string> A(a); //object A of class List with int items Note
}
