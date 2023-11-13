public class Example04_9 {
    public static void main(String[] args) {
        int a = 10, b = 0; 
        try {
            div(a, b);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void div(int x, int y) throws Exception {
        if (y == 0) {
            throw new Exception("被除数不能为0");
        } else {
            int result = x / y;
            System.out.println("结果为：" + result);
        }
    }
}