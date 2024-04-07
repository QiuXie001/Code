package control;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import model.ClassModel;
import model.Student;
import service.StudentService;
import service.impl.StudentServiceImpl;

/**
 * Servlet implementation class StudentServlet
 */
@WebServlet("/StudentServlet/*")
public class StudentServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	StudentService service = new StudentServiceImpl();

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public StudentServlet() {
		super();
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		doPost(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		// doGet(request, response);
		request.setCharacterEncoding("utf-8");
		response.setContentType("text/html;charset=utf-8");

		String uri = request.getRequestURI();
		if (uri.endsWith("/shows")) // ��ʾ��Ҫ��ʾȫ�����ݣ���ȡ�������ݽ�����ʾ
		{
			List<Student> curList = service.getAllStudent();

			System.out.println("--------------");
			System.out.println("curList.size:" + curList.size());
			request.setAttribute("studentList", curList);
			// ����ת����show.jsp����ʾȫ������
			request.getRequestDispatcher("/WEB-INF/views/shows.jsp").forward(request, response);

		}

		if (uri.endsWith("/update")) // ��ʾҪ�޸���Ϣ
		{
			// ���뵽�޸�ҳ��
			System.out.println("now start update..............");
			// �����޸�ʱ�������get��ʽ�����ģ�����Ӧ�ü�����Ҫ�޸ĵ����ݣ���ʾ���޸�ҳ�棬Ȼ������޸ģ��޸���Ϻ���б���
			String id = request.getParameter("id");
			System.out.println(id);
			if (request.getMethod().equalsIgnoreCase("get")) {
				System.out.println("get method..............");

				// �ڵ����޸�ҳ��ǰ���ȰѰ༶�б�����ϣ��ŵ��������У�ҳ���н��л�ȡ
				List<ClassModel> allClass = service.getAllClass();
				request.setAttribute("blongClass", allClass);

				Student curInfo = service.getOneStudent(id);
				request.setAttribute("updateStudent", curInfo);
				// ����ת����update.jsp�����������޸�
				request.getRequestDispatcher("/WEB-INF/views/update.jsp").forward(request, response);

			} else if (request.getMethod().equalsIgnoreCase("post")) // ��ʾ�޸�����Ҫ�ύ��������
			{
				System.out.println("post method..............");
				System.out.println("submit add data....................");

				Student nowData = new Student();
				nowData.setStuCode(request.getParameter("stuCode"));
				nowData.setStuName(request.getParameter("stuName"));
				nowData.setAge(Integer.parseInt(request.getParameter("age")));
				nowData.setSex(Integer.parseInt(request.getParameter("sex")));

				SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
				try {
					nowData.setBirthday(sdf.parse(request.getParameter("birthday")));
				} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				int curClassId = Integer.parseInt(request.getParameter("curClassId"));
				nowData.setBelongClass(curClassId);
				System.out.println("classId" + curClassId);

				// ���ݰ༶id����ȡ�༶���ƴ��롣����ʽ��������ʱ�����������ݿ���ֱ�ӹ�����ȡ�����ý����ƴ������ݿ�
				String curClassName = service.getOneClassById(curClassId);
				nowData.setBelongClassName(curClassName);

				service.updateStudent(nowData);
				// ��ת����ҳ�棬�����������¼���
				response.sendRedirect("/studentManagement/index.jsp");

			}

		}

		if (uri.endsWith("/delete")) // ��ʾҪɾ����Ϣ
		{
			// ���뵽ɾ��ҳ��
			System.out.println("now start delete....................");
			String id = request.getParameter("id");
			System.out.println(id);

			service.deleteStudent(id);
			response.sendRedirect("/studentManagement/index.jsp");

		}

		if (uri.endsWith("/add")) // ��ʾ������Ϣ
		{
			// ���뵽����ҳ��
			System.out.println("now start add....................");
			// ����Ǵӳ����ӷ�ʽ�����ģ���ʱ��Ҫ��������ҳ�� ����������ʽ��get�ķ�ʽ
			if (request.getMethod().equalsIgnoreCase("get")) {
				// �ڵ�������ҳ��ǰ���ȰѰ༶�б�����ϣ��ŵ��������У�ҳ���н��л�ȡ
				List<ClassModel> allClass = service.getAllClass();
				request.setAttribute("blongClass", allClass);
				// ����ת����add.jsp��������Ϣ
				request.getRequestDispatcher("/WEB-INF/views/add.jsp").forward(request, response);
			} else if (request.getMethod().equalsIgnoreCase("post")) // ˵����������ύ��Ϣ����������ҳ����ύʱ���ñ��ķ�ʽ�ύ��
			{

				// ����������֮ǰ����Ҫ������У�飬���粻Ϊ�յ�У�飬�Ƿ�Ϊ���ֵ�У���
				// ѧ���Լ���

				// �ύ��������
				System.out.println("submit add data....................");
				Student nowData = new Student();
				nowData.setStuCode(request.getParameter("stuCode"));
				nowData.setStuName(request.getParameter("stuName"));
				nowData.setAge(Integer.parseInt(request.getParameter("age")));
				nowData.setSex(Integer.parseInt(request.getParameter("sex")));

				SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
				try {
					nowData.setBirthday(sdf.parse(request.getParameter("birthday")));
				} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				int curClassId = Integer.parseInt(request.getParameter("curClassId"));
				nowData.setBelongClass(curClassId);
				System.out.println("classId" + curClassId);
				// ���ݰ༶id����ȡ�༶���ƴ��롣ע��ʽ��������ʱ�����������ݿ���ֱ�ӹ�����ȡ�����ý����ƴ������ݿ�
				String curClassName = service.getOneClassById(curClassId);
				nowData.setBelongClassName(curClassName);

				service.addNewStudent(nowData);
				// ��ת����ҳ�棬�����������¼���
				response.sendRedirect("/studentManagement/index.jsp");

			}

		}

	}

}
