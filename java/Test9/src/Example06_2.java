import java.util.HashSet;

class Student implements Comparable{
  private String name;
  private int age;
  public Student(String name,int age) {
     this.name = name;    
     this.age = age;
  }
 public String toString() {
      return name + ":" + age;
 }
 public boolean equals(Object o){
    System.out.println("equals()..........");
    if(this ==o) return true;
    if(o==null||getClass()!=o.getClass())
    return false;
    Student student = (Student)o;
    if(age!=student.age)
    return false;
    return name!=null?name.equals(student.name):student.name==null;
 }
 public int hashCode() {
    int result = name !=null ?name.hashCode():0;
    result = result +age;
    return result;
 }
  public int compareTo(Object obj) {
      Student stu = (Student)obj;
      //定义比较方式，先比较age，再比较name
      if(this.age - stu.age > 0){
         return 1;
      }
      if(this.age - stu.age == 0){
          return this.name.compareTo(stu.name);
      }
     return -1;
  }
}
public class Example06_2 {
    public static void main(String[] args) {
    HashSet<Student> hs = new HashSet<>();
    hs.add(new Student("Lucy",18));
    hs.add(new Student("Tom",20));
    hs.add(new Student("Bob",20));
    hs.add(new Student("Tom",20));
    hs.add(new Student("Tom",30));
    System.out.println(hs.toString());
    for(Student i : hs){
        System.out.println(i.hashCode());
    }
    
    }
}

