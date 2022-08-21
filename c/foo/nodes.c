#include <stdio.h>
#include <unistd.h>
#include <string.h>
#include <stdlib.h>

#define TRUE 0
#define FALSE 1

typedef struct myStruct myStruct;

struct myStruct
{
    int        size;
    char      *name;
    myStruct **array;
};

myStruct *allocate_node(char *name, int size)
{
    myStruct *p_node;
    if (size < 0)
        size = 0;
    p_node = calloc(1, sizeof(myStruct));
    p_node->name = name;
    p_node->size = size;
    p_node->array = calloc(1, size * sizeof(myStruct *));

    return p_node;
}

void expand_node_child_array(myStruct *p_node, int size_to_add)
{
    if (size_to_add < 1 || p_node == NULL)
        return;
    if (p_node->array == NULL)
    {
        p_node->size = size_to_add;
        p_node->array = calloc(1, size_to_add * sizeof(myStruct *));
    }
    else
    {
        p_node->array = realloc(p_node->array, (p_node->size + size_to_add) * sizeof(myStruct *));
        memset(p_node->array + p_node->size * sizeof(myStruct *), 0, size_to_add * sizeof(myStruct *));
        p_node->size += size_to_add;
    }
}

myStruct *get_child_node(myStruct *p_node, int index)
{
    if (index < 0 || index >= p_node->size)
        return 0;
    return p_node->array[index];
}

int set_child_node(myStruct *p_node, int index, myStruct *p_child)
{
    if (index < 0 || index >= p_node->size)
        return FALSE;
    p_node->array[index] = p_child;
    return TRUE;
}

void free_node(myStruct **pp_node)
{
    // Free p_node and the array but DO NOT free the children
    if (pp_node == NULL || *pp_node == NULL)
        return;
    if ((*pp_node)->array != NULL)
        free((*pp_node)->array);
    free((*pp_node));
    *pp_node = NULL;
}

void free_node_and_children(myStruct **pp_node)
{
    int iChild;

    if (pp_node == NULL || *pp_node == NULL)
        return;
    for (iChild = 0; iChild < (*pp_node)->size; iChild++)
    {
        myStruct *p_child = get_child_node((*pp_node), iChild);
        if (p_child != NULL)
            free_node_and_children(&p_child);
        set_child_node((*pp_node), iChild, NULL);
    }
    free_node(pp_node);
}

void dump_nodes_recursive(myStruct *p_node, int level)
{
    if (p_node == NULL)
    {
        printf("%*s", 4*level, " ");
        printf("NULL\n");
    }
    else
    {
        int iChild;
        printf("%*s", 4*level, " ");
        printf("Node: Name=\"%s\", array size=%d\n", p_node->name, p_node->size);
        for (iChild = 0; iChild < p_node->size; iChild++)
        {
            myStruct *p_child = get_child_node(p_node, iChild);
            printf("%*s", 4*level, " ");
            printf("Child [%d]:\n", iChild);
            dump_nodes_recursive(p_child, level+1);
        }
    }
}

void dump_nodes(myStruct *p_node)
{
    dump_nodes_recursive(p_node, 0);
}

void test_my_struct()
{
    myStruct *p_top = allocate_node("top", 4);
    myStruct *p_child0 = allocate_node("child0", 1);
    myStruct *p_child1 = allocate_node("child1", 5);
    myStruct *p_child2 = allocate_node("child2", 0);
    myStruct *p_child3 = allocate_node("child3", 0);
    myStruct *p_child00 = allocate_node("child00", 0);

    set_child_node(p_top, 0, p_child0);
    set_child_node(p_top, 1, p_child1);
    set_child_node(p_top, 2, p_child2);

    set_child_node(p_top, 3, p_child3);

    set_child_node(p_child0, 0, p_child00);

    dump_nodes(p_top);

    free_node_and_children(&p_top);
}

int main(void) {
    test_my_struct();
}
