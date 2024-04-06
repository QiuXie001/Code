package dao.impl;

import java.util.*;

import dao.ClassDao;
import model.ClassModel;

public class ClassDaoImpl implements ClassDao {

	// ���������ݿ�����ȡ������ģ�����7���༶
	public static List<ClassModel> list = new ArrayList<ClassModel>();
	static {
		for (int i = 1; i < 8; i++) {
			ClassModel tmp = new ClassModel();
			tmp.setClassId(i);
			tmp.setClassName(i + "��");
			list.add(tmp);
		}
	}

	@Override
	public List<ClassModel> getAllClass() {
		// TODO Auto-generated method stub

		return list;
	}

	@Override
	public String getClassNameByClassId(int id) {
		// TODO Auto-generated method stub
		for (int i = 0; i < list.size(); i++) {
			if (list.get(i).getClassId() == id) {
				return list.get(i).getClassName();
			}
		}
		return "";
	}

}
