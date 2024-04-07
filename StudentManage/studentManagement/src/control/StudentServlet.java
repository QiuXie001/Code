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
		if (uri.endsWith("/shows")) // 表示需要显示全部数据，提取所有数据进行显示
		{
			List<Student> curList = service.getAllStudent();

			System.out.println("--------------");
			System.out.println("curList.size:" + curList.size());
			request.setAttribute("studentList", curList);
			// 请求转发给show.jsp，显示全部数据
			request.getRequestDispatcher("/WEB-INF/views/shows.jsp").forward(request, response);

		}

		if (uri.endsWith("/update")) // 表示要修改信息
		{
			// 进入到修改页面
			System.out.println("now start update..............");
			// 进行修改时，如果是get方式过来的，首先应该加载需要修改的数据，显示到修改页面，然后进行修改，修改完毕后进行保存
			String id = request.getParameter("id");
			System.out.println(id);
			if (request.getMethod().equalsIgnoreCase("get")) {
				System.out.println("get method..............");

				// 在弹出修改页面前，先把班级列表加载上，放到请求域中，页面中进行获取
				List<ClassModel> allClass = service.getAllClass();
				request.setAttribute("blongClass", allClass);

				Student curInfo = service.getOneStudent(id);
				request.setAttribute("updateStudent", curInfo);
				// 请求转发给update.jsp，进行数据修改
				request.getRequestDispatcher("/WEB-INF/views/update.jsp").forward(request, response);

			} else if (request.getMethod().equalsIgnoreCase("post")) // 表示修改完需要提交保存数据
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

				// 根据班级id，获取班级名称存入。在正式开发程序时，正常从数据库中直接关联提取，不用将名称存入数据库
				String curClassName = service.getOneClassById(curClassId);
				nowData.setBelongClassName(curClassName);

				service.updateStudent(nowData);
				// 跳转到主页面，进行数据重新加载
				response.sendRedirect("/studentManagement/index.jsp");

			}

		}

		if (uri.endsWith("/delete")) // 表示要删除信息
		{
			// 进入到删除页面
			System.out.println("now start delete....................");
			String id = request.getParameter("id");
			System.out.println(id);

			service.deleteStudent(id);
			response.sendRedirect("/studentManagement/index.jsp");

		}

		if (uri.endsWith("/add")) // 表示新增信息
		{
			// 进入到新增页面
			System.out.println("now start add....................");
			// 如果是从超链接方式过来的，此时需要弹出增加页面 过来的请求方式是get的方式
			if (request.getMethod().equalsIgnoreCase("get")) {
				// 在弹出新增页面前，先把班级列表加载上，放到请求域中，页面中进行获取
				List<ClassModel> allClass = service.getAllClass();
				request.setAttribute("blongClass", allClass);
				// 请求转发给add.jsp，新增信息
				request.getRequestDispatcher("/WEB-INF/views/add.jsp").forward(request, response);
			} else if (request.getMethod().equalsIgnoreCase("post")) // 说明新增完毕提交信息（弹出新增页面后，提交时，用表单的方式提交）
			{

				// 正常在新增之前还需要做数据校验，比如不为空的校验，是否为数字的校验等
				// 学生自己加

				// 提交新增数据
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
				// 根据班级id，获取班级名称存入。注正式开发程序时，正常从数据库中直接关联提取，不用将名称存入数据库
				String curClassName = service.getOneClassById(curClassId);
				nowData.setBelongClassName(curClassName);

				service.addNewStudent(nowData);
				// 跳转到主页面，进行数据重新加载
				response.sendRedirect("/studentManagement/index.jsp");

			}

		}

	}

}
