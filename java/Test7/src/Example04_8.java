public class Example04_8 {
    public static void main(String[] args) {
        try {
            // 模拟可能发生异常的语句
            int result = 10 / 0;
            System.out.println("程序继续"); // 如果没有异常，将执行这句话
        } catch (ArithmeticException e) {
            System.out.println("出现异常");
        } finally {
            System.out.println("释放资源");
        }
    }
}