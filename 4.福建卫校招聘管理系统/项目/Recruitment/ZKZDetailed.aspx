<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZKZDetailed.aspx.cs" Inherits="Recruitment.ZKZDetailed" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .bod {
            width:595px;
            height:960px;
           overflow:hidden;
            margin:0px auto;
            border:1px solid #000000;
            margin-top:10px;
           
            
        }
        h4 {
            text-align:center;
        }
        h2 {
            text-align:center;
        }
        p {
            margin-left:22px;
            
            margin-top:-5px;
            font-family:微软雅黑;
            font-size:15px;
        }
        .wrap {
        }
        .zuo {
            float:left;
        }
        .you {
            float:right;
        }
        .cun {width:148px;
              height:206px;
             
             
              margin-right:32px;
              margin-top:40px;
        }
        .zhuyi { width:560px;
                 height:100px;
                 margin:0px auto;
           
                
        }
            .zhuyi span {
                
                font-size:14px;
            }
    </style>
        <script type="text/javascript">
        //-----  下面是打印控制语句  ----------
        window.onbeforeprint = beforePrint;
        window.onafterprint = afterPrint;
        //打印之前隐藏不想打印出来的信息
        function beforePrint() {
            div2.style.display = 'none';
            div3.style.display = 'none';

        }
        //打印之后将隐藏掉的信息再显示出来
        function afterPrint() {
            div2.style.display = '';
            div3.style.display = '';
        }
        function printPage() {
            //  parent.iprint.style.display = "none";
            div2.style.display = "none";
            //   $("div3").css("display", "none");
            window.print();
            div2.style.display = "block";
            //  $("div3").css("display", "");
            return false;
        }
       

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="bod" >
        <div class="top"><h4 >福建卫生职业技术学院编内工作人员统一考试（笔试）</h4></div>
        <h2>准考证</h2>
        <div class="wrap">
        <div class="zuo">
        <p>姓名：<asp:Label ID="LName" runat="server" ></asp:Label>
            </p>
      
        <p>证件号码：<asp:Label ID="LIDCard" runat="server" ></asp:Label></p>
        <p>报考单位：福建卫生职业技术学院</p>
        <p>岗位代码：<asp:Label ID="LJobCode" runat="server" ></asp:Label></p>
        <p>考点名称：福建卫生职业技术学院</p>
        <p>考点地址：福州市闽侯荆溪关口366号</p>
        <p><span>考室号：<asp:Label ID="LTestAddress" runat="server" ></asp:Label></span></p>
        <p>考试时间及科目：</p>
               
        </div>
        <div class="you">
            <div class="cun" > <img  id="Image2" runat="server" src="~/imgs.aspx" style="width:100%;height:100%; padding:0; margin:0;" /></div>
        </div>
        </div> 
        <div>
              <asp:GridView ID="GridView1" runat="server"   
                  Width="98%" AllowPaging="True"  AutoGenerateColumns="False"
                           PageSize="10">
                     
                        <Columns>
                            <asp:BoundField DataField="ExamSubject" HeaderText="考试科目">
                           
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>   
                            <asp:BoundField DataField="ExamDate" HeaderText="考试日期">
                                
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>   
                              <asp:BoundField DataField="ExamTime" HeaderText="考试时间">
                              
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>        
                         
                        </Columns>
               
                    </asp:GridView>
        </div>
      
     <div class="zhuyi"><a style="margin-left:-10px;" ><strong>注意事项：</strong></a>
         <br />
<%=MenuStr %>
     </div>  
    </div>
          <div id="div2"   style="text-align: center; margin-top:10px;  ">
            <input id="div3" type="button" value="打 印" onclick=" printPage() " style="    width:60px; height:30px;    background:none;     border:1px solid #000; border-radius:13px; text-align:center; line-height:30px;  cursor:pointer;" />
           
        </div>
     
    </form>
</body>
</html>
