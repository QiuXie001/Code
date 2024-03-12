/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var first = new ListNode();
        var now = first;
        int up = 0;
        if(l1 != null && l2 != null)
        {
            int val = (l1.val+l2.val)+up;
            up = val % 10;
            val = val / 10;
            now.val = val;
            now.next = new ListNode();
            now = now.next;
            l1=l1.next;
            l2=l2.next;
        }
        return first;
    }
}
// @lc code=end

