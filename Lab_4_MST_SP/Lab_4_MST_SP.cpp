﻿#include <iostream>

using namespace std;

struct edge{

	int vertex1; //data members
	int vertex2;
	int weight;
	edge* next; //link member

	edge() {
		vertex1 = 0;
		vertex2 = 0;
		weight = 0;
		next = NULL;
	}
	edge(int v1, int v2, int w) //constructor
	{
		vertex1 = v1;
		vertex2 = v2;
		weight = w;
		next = NULL;
	}
};

typedef edge* p_edge;

//A Graph object is created via dialog with a user.
//The object is represented by linked adjacency lists unsorted by numbers of vertices.
class Graph{
public:
	Graph();
	~Graph();
	int Nodes_number();
	int Edges_number();

private:
	int n; // number of vertices
	int m; // number of edges in graph or digraph
	p_edge* adjacencyList; //pointer to array of pointers to adjacency lists
	void Print_list(int);
};

//Constructor

Graph::Graph(){ 
	int edge_weight; //to read edge weights
	int answer; //to read numbers of adjacent vertices

	cout << "Enter number of graph vertices ==> ";
	cin >> n;

	//A dynamic array of pointers to linked adjacency lists is created and initialized.
	adjacencyList = new p_edge[n + 1, NULL];
	for (int i = 1; i <= n; i++) adjacencyList[i] = NULL;

	int edge_count = 0;
	for (int i = 1; i <= n; i++) //Adjacency linked lists for an input graph are created.
	{
		cout << " \nADJACENCY LIST for graph VERTEX #" << i << endl;
		answer = 1;
		while (answer != -1)
		{
			cout << "Enter number of current adjacent vertex (-1 to finish) ==> ";
			cin >> answer;
			if (answer == -1) break;
			if (answer >= 1 && answer <= n)
			{
				cout << "Enter integer weight of edge " << i << "--" << answer << " ==> ";
				cin >> edge_weight;
				/*if(check node) contiue*/
				//insert new node in linked list of i
				//insert new node in linked list of answer
				edge_count++;
			}
			else cout << "VERTEX NUMBER IS OUT OF RANGE!!\n";
		}
	}
	m = edge_count;
	cout << "\nADJACENCY LISTS for each vertex of input graph:\n";
	for (int i = 1; i <= n; i++)
	{
		cout << "list for vertex #" << i << ": ";
		//Print_list(i);
	}
}// constructor

//Destructor



// Metods of class



int main()
{
    
}
