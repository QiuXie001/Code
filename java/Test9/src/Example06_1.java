import java.util.ArrayList;

public class Example06_1 {  
    public static void main(String[] args) {
         // 创建一个 ArrayList 集合
        ArrayList<String> list = new ArrayList<>();

        // 向集合中添加元素
        list.add("元素1");
        list.add("元素2");
        list.add("元素3");

        // 遍历集合并输出元素
        for (String element : list) {
            System.out.println(element);
        }
    }
}