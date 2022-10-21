using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;

    [SerializeField] private int maxDepth = 3;

    [SerializeField] private int rootLength = 4;

    [SerializeField][Range(0, 1)] private float reductionPerLevel = 0.1f;

    private float currentLength = -1;
    private int currentDepth = 1;

    private Queue<GameObject> frontier = new Queue<GameObject>();


    private void Start()
    {
        GameObject root = Instantiate(branchPrefab, transform);
        SetBranchLength(root, rootLength);
        root.name = "root branch";

        currentLength = rootLength;
        frontier.Enqueue(root);

        GenerateTree();
    }

    private void GenerateTree()
    {
        if (currentDepth > maxDepth) return;

        ++currentDepth;

        currentLength -= currentLength * reductionPerLevel;
        Queue<GameObject> newBranches = new Queue<GameObject>();
        while (frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            var leftBranch = CreateBranch(branch, Random.Range(10f, 40f)); 
            var rightBranch = CreateBranch(branch, -Random.Range(10f, 40f));

            SetBranchLength(leftBranch, currentLength);
            SetBranchLength(rightBranch, currentLength);

            newBranches.Enqueue(leftBranch);
            newBranches.Enqueue(rightBranch);
        }

        frontier = newBranches;

        GenerateTree();
    }

    private GameObject CreateBranch(GameObject prevBranch, float offsetAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);

        //newBranch.transform.position = prevBranch.transform.position + prevBranch.transform.up * GetBranchLength(prevBranch);
        Transform line = prevBranch.transform.GetChild(0);
        newBranch.transform.position = prevBranch.transform.position + prevBranch.transform.up * line.localScale.y;
        newBranch.transform.rotation = prevBranch.transform.rotation * Quaternion.Euler(0f, 0f, offsetAngle);

        return newBranch;
    }

    private void SetBranchLength(GameObject branch, float lenght)
    {
        Transform line = branch.transform.GetChild(0);
        Transform circle = branch.transform.GetChild(1);
        line.localScale = new Vector3(line.localScale.x, lenght, line.localScale.z);
        line.localPosition = new Vector3(line.localPosition.x, lenght / 2, line.localPosition.z);
        circle.localPosition = new Vector3(circle.localPosition.x, lenght, circle.localPosition.z);
    }

    //private float GetBranchLength(GameObject branch)
    //{
    //    Transform line = branch.transform.GetChild(0);
    //    return line.localScale.y;
    //}

}
