package dao;

import java.util.List;

import model.ClassModel;

public interface ClassDao {

	// ��ȡ���а༶��Ϣ
	public List<ClassModel> getAllClass();

	// ���ݰ༶Id��ȡ�༶����
	public String getClassNameByClassId(int id);

}
