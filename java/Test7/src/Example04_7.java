
public class Example04_7 {
    private int[] arr = {1, 2, 3};
    
    public static void main(String[] args) {
        Example04_7 example = new Example04_7();
        example.traverseArray();
    }
    public void traverseArray() {
        try {
            for (int i = 0; i <= arr.length; i++) {
                System.out.println(arr[i]);
            }
            System.out.println("over");
        } catch (ArrayIndexOutOfBoundsException e) {
            System.out.println("下标越界");
        }
    }
}