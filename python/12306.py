#!/usr/bin/env python
# coding=gb2312
 
"""
ͨ��splinterˢ12306��Ʊ
�����½ҳ�棬����ѡ��ɨ���½�����˺������½
��½�ɹ��󣬽����������飬���ɽű������ˣ������ĵȴ���Ʊ����ͺã�ˢƱ�����У���������ɹرգ�
��Ʊ�ɹ���������ֻ����ź��ʼ���֪ͨ
author: cuizy
time: 2018-11-21
"""
 
import re
from splinter.browser import Browser
from time import sleep
import sys
import httplib2
from urllib import parse
import smtplib
from email.mime.text import MIMEText
import time
 
 
class BrushTicket(object):
    """��Ʊ�༰ʵ�ַ���"""
 
    def __init__(self, passengers, from_time, from_station, to_station, number, seat_type, receiver_mobile,
                 receiver_email):
        """����ʵ�����ԣ���ʼ��"""
        # �˿�����
        self.passengers = passengers
        # ��ʼվ���յ�վ
        self.from_station = from_station
        self.to_station = to_station
        # �˳�����
        self.from_time = from_time
        # ���α��
        self.number = number.capitalize()
        # ��λ��������tdλ��
        if seat_type == '�������ص���':
            seat_type_index = 1
            seat_type_value = 9
        elif seat_type == 'һ����':
            seat_type_index = 2
            seat_type_value = 'M'
        elif seat_type == '������':
            seat_type_index = 3
            seat_type_value = 0
        elif seat_type == '�߼�����':
            seat_type_index = 4
            seat_type_value = 6
        elif seat_type == '����':
            seat_type_index = 5
            seat_type_value = 4
        elif seat_type == '����':
            seat_type_index = 6
            seat_type_value = 'F'
        elif seat_type == 'Ӳ��':
            seat_type_index = 7
            seat_type_value = 3
        elif seat_type == '����':
            seat_type_index = 8
            seat_type_value = 2
        elif seat_type == 'Ӳ��':
            seat_type_index = 9
            seat_type_value = 1
        elif seat_type == '����':
            seat_type_index = 10
            seat_type_value = 1
        elif seat_type == '����':
            seat_type_index = 11
            seat_type_value = 1
        else:
            seat_type_index = 7
            seat_type_value = 3
        self.seat_type_index = seat_type_index
        self.seat_type_value = seat_type_value
        # ֪ͨ��Ϣ
        self.receiver_mobile = receiver_mobile
        self.receiver_email = receiver_email
        # �°�12306������Ҫҳ����ַ
        self.login_url = 'https://kyfw.12306.cn/otn/resources/login.html'
        self.init_my_url = 'https://kyfw.12306.cn/otn/view/index.html'
        self.ticket_url = 'https://kyfw.12306.cn/otn/leftTicket/init?linktypeid=dc'
        # �����������Ϣ����������ҳ��https://sites.google.com/a/chromium.org/chromedriver/downloads
        self.driver_name = 'chrome'
        self.driver = Browser(driver_name=self.driver_name)
 
    def do_login(self):
        """��¼����ʵ�֣��ֶ�ʶ����֤����е�¼"""
        self.driver.visit(self.login_url)
        sleep(1)
        # ѡ���½��ʽ��½
        print('��ɨ���½�����˺ŵ�½����')
        while True:
            if self.driver.url != self.init_my_url:
                sleep(1)
            else:
                break
 
    def start_brush(self):
        """��Ʊ����ʵ��"""
        # ������������
        self.driver.driver.maximize_window()
        # ��½
        self.do_login()
        # ��ת����Ʊҳ��
        self.driver.visit(self.ticket_url)
        try:
            print('��ʼˢƱ����')
            # ���س�Ʊ��ѯ��Ϣ
            self.driver.cookies.add({"_jc_save_fromStation": self.from_station})
            self.driver.cookies.add({"_jc_save_toStation": self.to_station})
            self.driver.cookies.add({"_jc_save_fromDate": self.from_time})
            self.driver.reload()
            count = 0
            while self.driver.url == self.ticket_url:
                try:
                    self.driver.find_by_text('��ѯ').click()
                except Exception as error_info:
                    print(error_info)
                    sleep(1)
                    continue
                sleep(0.5)
                count += 1
                local_date = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())
                print('��%d�ε����ѯ����[%s]' % (count, local_date))
                try:
                    current_tr = self.driver.find_by_xpath('//tr[@datatran="' + self.number + '"]/preceding-sibling::tr[1]')
                    if current_tr:
                        if current_tr.find_by_tag('td')[self.seat_type_index].text == '--':
                            print('�޴���λ���ͳ��ۣ��ѽ�����ǰˢƱ�������¿�����')
                            sys.exit(1)
                        elif current_tr.find_by_tag('td')[self.seat_type_index].text == '��':
                            print('��Ʊ���������ԡ���')
                            sleep(1)
                        else:
                            # ��Ʊ������Ԥ��
                            print('ˢ��Ʊ�ˣ���Ʊ����' + str(current_tr.find_by_tag('td')[self.seat_type_index].text) + '������ʼ����Ԥ������')
                            current_tr.find_by_css('td.no-br>a')[0].click()
                            sleep(1)
                            key_value = 1
                            for p in self.passengers:
                                if '()' in p:
                                    p = p[:-1] + 'ѧ��' + p[-1:]
                                # ѡ���û�
                                print('��ʼѡ���û�����')
                                self.driver.find_by_text(p).last.click()
                                # ѡ����λ����
                                print('��ʼѡ��ϯ�𡭡�')
                                if self.seat_type_value != 0:
                                    self.driver.find_by_xpath(
                                        "//select[@id='seatType_" + str(key_value) + "']/option[@value='" + str(
                                            self.seat_type_value) + "']").first.click()
                                key_value += 1
                                sleep(0.2)
                                if p[-1] == ')':
                                    self.driver.find_by_id('dialog_xsertcj_ok').click()
                            print('�����ύ��������')
                            sleep(2)
                            self.driver.find_by_id('submitOrder_id').click()
                            sleep(2)
                            # �鿴�Żؽ���Ƿ�����
                            submit_false_info = self.driver.find_by_id('orderResultInfo_id')[0].text
                            if submit_false_info != '':
                                print(submit_false_info)
                                self.driver.find_by_id('qr_closeTranforDialog_id').click()
                                sleep(0.2)
                                self.driver.find_by_id('preStep_id').click()
                                sleep(0.3)
                                continue
                            print('����ȷ�϶�������')
                            self.driver.find_by_id('qr_submit_id').click()
                            print('Ԥ���ɹ����뼰ʱǰ��֧������')
                            # ����֪ͨ��Ϣ
                            self.send_mail(self.receiver_email, '��ϲ��������Ʊ�ˣ��뼰ʱǰ��12306֧��������')
                            self.send_sms(self.receiver_mobile, '������֤���ǣ�8888���벻Ҫ����֤��й¶�������ˡ�')
                    else:
                        print('��ǰ���Ρ�%s��δ��Ʊ��' % self.number)
                        self.driver.visit(self.ticket_url)
                except Exception as error_info:
                    print(error_info)
                    # ��ת����Ʊҳ��
                    self.driver.visit(self.ticket_url)
        except Exception as error_info:
            print(error_info)
 
    def send_sms(self, mobile, sms_info):
        """�����ֻ�֪ͨ���ţ��õ���-��������-�Ĳ��Զ���"""
        host = "106.ihuyi.com"
        sms_send_uri = "/webservice/sms.php?method=Submit"
        account = "C59782899"
        pass_word = "19d4d9c0796532c7328e8b82e2812655"
        params = parse.urlencode(
            {'account': account, 'password': pass_word, 'content': sms_info, 'mobile': mobile, 'format': 'json'}
        )
        headers = {"Content-type": "application/x-www-form-urlencoded", "Accept": "text/plain"}
        conn = httplib2.HTTPConnectionWithTimeout(host, port=80, timeout=30)
        conn.request("POST", sms_send_uri, params, headers)
        response = conn.getresponse()
        response_str = response.read()
        conn.close()
        return response_str
 
    def send_mail(self, receiver_address, content):
        """�����ʼ�֪ͨ"""
        # ���������������Ϣ
        host = 'smtp.163.com'
        port = 25
        sender = 'gxcuizy@163.com'  # ��ķ����������
        pwd = '******'  # ���ǵ�½���룬�ǿͻ�����Ȩ����
        # ������Ϣ
        receiver = receiver_address
        body = '<h2>��ܰ���ѣ�</h2><p>' + content + '</p>'
        msg = MIMEText(body, 'html', _charset="utf-8")
        msg['subject'] = '��Ʊ�ɹ�֪ͨ��'
        msg['from'] = sender
        msg['to'] = receiver
        s = smtplib.SMTP(host, port)
        # ��ʼ��½���䣬�������ʼ�
        s.login(sender, pwd)
        s.sendmail(sender, receiver, msg.as_string())
 
 
if __name__ == '__main__':
    # �˿�����
    passengers_input = input('������˳���������������Ӣ�Ķ��š�,�����ӣ������絥�ˡ����������߶��ˡ�����,���ġ������ѧ���Ļ����롰����()������')
    passengers = passengers_input.split(",")
    while passengers_input == '' or len(passengers) > 4:
        print('�˳�������1λ�����4λ��')
        passengers_input = input('����������˳���������������Ӣ�Ķ��š�,�����ӣ������絥�ˡ����������߶��ˡ�����,���ġ�����')
        passengers = passengers_input.split(",")
    # �˳�����
    from_time = input('������˳����ڣ����硰2018-08-08������')
    date_pattern = re.compile(r'^\d{4}-\d{2}-\d{2}$')
    while from_time == '' or re.findall(date_pattern, from_time) == []:
        from_time = input('�˳����ڲ���Ϊ�ջ���ʱ���ʽ����ȷ�����������룺')
    # ����cookie�ֵ�
    city_list = {
        'bj': '%u5317%u4EAC%2CBJP',  # ����
        'hd': '%u5929%u6D25%2CTJP',  # ����
        'nn': '%u5357%u5B81%2CNNZ',  # ����
        'wh': '%u6B66%u6C49%2CWHN',  # �人
        'cs': '%u957F%u6C99%2CCSQ',  # ��ɳ
        'ty': '%u592A%u539F%2CTYV',  # ̫ԭ
        'yc': '%u8FD0%u57CE%2CYNV',  # �˳�
        'gzn': '%u5E7F%u5DDE%u5357%2CIZQ',  # ������
        'wzn': '%u68A7%u5DDE%u5357%2CWBZ',  # ������
        'njn': '%u5357%u4EAC%u5357%2CNKH',#�Ͼ���
        'yc':'%u76D0%u57CE%2CAFH',#�γ�
        'cc':'%u957F%u6625%2CCCT',#����
    }
    # ����վ
    from_input = input('���������վ��ֻ��Ҫ��������ĸ���У����籱����bj������')
    while from_input not in city_list.keys():
        from_input = input('����վ����Ϊ�ջ�֧�ֵ�ǰ����վ��������Ҫ������ϵ����Ա���������������룺')
    from_station = city_list[from_input]
    # �յ�վ
    to_input = input('�������յ�վ��ֻ��Ҫ��������ĸ���У����籱����bj������')
    while to_input not in city_list.keys():
        to_input = input('�յ�վ����Ϊ�ջ�֧�ֵ�ǰ�յ�վ��������Ҫ������ϵ����Ա���������������룺')
    to_station = city_list[to_input]
    # ���α��
    number = input('�����복�κţ����硰G110������')
    while number == '':
        number = input('���κŲ���Ϊ�գ����������룺')
    # ��λ����
    seat_type =input('��������λ���ͣ����硰���ԡ�����')
    while seat_type == '':
        seat_type = input('��λ���Ͳ���Ϊ�գ����������룺')
    # ��Ʊ�ɹ���֪ͨ���ֻ�����
    receiver_mobile = '18151939379' #input('��Ԥ��һ���ֻ����룬��������Ʊ�����֪ͨ�����磺18888888888����')
    mobile_pattern = re.compile(r'^1{1}\d{10}$')
    while receiver_mobile == '' or re.findall(mobile_pattern, receiver_mobile) == []:
        receiver_mobile = input('Ԥ���ֻ����벻��Ϊ�ջ��߸�ʽ����ȷ�����������룺')
    receiver_email = '1357947563@qq.com'#input('��Ԥ��һ�����䣬��������Ʊ�����֪ͨ�����磺test@163.com����')
    while receiver_email == '':
        receiver_email = input('Ԥ�����䲻��Ϊ�գ����������룺')
    # ��ʼ��Ʊ
    ticket = BrushTicket(passengers, from_time, from_station, to_station, number, seat_type, receiver_mobile,
                         receiver_email)
    ticket.start_brush()