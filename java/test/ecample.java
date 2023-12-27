
interface Inter {
    public void show();
}
abstract class AbstractInter implements Inter{
    public void show(){
        System.out.println("AbstractInter show()");
    }
}
class InterImpl extends AbstractInter{
    public void show(){
        System.out.println("InterImpl show()");
    }
}
public class ecample {
    public static void main(String[] args) {
    InterImpl i =new InterImpl();
    i.show();
}
}
