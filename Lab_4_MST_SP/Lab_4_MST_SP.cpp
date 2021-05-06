#include <iostream>

using namespace std;

struct edge{

	int vertex1; //data members
	int vertex2;
	int weight;
	edge* next; //link member

	edge(int v1, int v2, int w) //constructor
	{
		vertex1 = v1;
		vertex2 = v2;
		weight = w;
		next = NULL;
	}
};

int main()
{
    
}
