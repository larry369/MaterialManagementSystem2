# MaterialManagementSystem2
 <h1>登入頁面</h1>
 <div>
 <div>
 <h3>登入驗證</h3>
 <ul>
  <li>登入<br/><span>(驗證登入者工號、密碼)</span></li>
 </ul>
 </div>
 
 </div>
 
 
 
 
 <h1>主頁面</h1>
 <div>

 <div>
 <h3>料件清單</h3>
 <ul>
  <li>料件查詢</li>
  <li>請購<br/><span>(選擇欲補貨的庫存料件至新增料件頁面)</span></li>
  <li>修改<br/><span>(管理者權限)</span></li>
  <li>刪除<br/><span>(管理者權限)</span></li>
 </ul>
 </div>
 <div>
 <h3>請購料件</h3>
 <ul>
  <li>送審<br/><span>(1.庫存料件補貨請購<span>#由料件清單頁面請購導入資料</span><br/>2.新增新的料件至庫存)</span></li>
  <li>收回<br/><span>(審核中的單號可收回，通過及未通過的不可收回)</span></li>
 </ul>
 </div>
 <div>
 <h3>廠商列表</h3>
 <ul>
  <li>編輯<br/><span>(開啟新增、清空(新增時清空表格內容)、修改功能(管理者))</span></li>
  <li>刪除<br/><span>(刪除供應商資料)</span></li>
  <li>+(新增料件)<br/><span>(廠商選取後，針對選擇廠商增加供應商供應料件)</span></li>
  <li>刪除<br/><span>(刪除供應商料件)</span></li>
 </ul>
 </div>
 <div>
 <h3>審核料件(管理者權限)</h3>
 <ul>
  <li>通過<br/><span>(審核結果存回送審的table，同時新增到庫存料件，如為原有庫存補貨則為審核結果存回送審的table，同時修改原有庫存料件的數量，)</span></li>
  <li>未通過<br/><span>(審核結果存回送審的table)</span></li>
 </ul>
 </div>
 <div>
 <h3>員工管理(管理者權限)</h3>
 <ul>
  <li>新增<br/><span>(新增員工，新員工密碼預設為0000，員工登入後再自行更改#此功能尚未加入)</span></li>
  <li>修改<br/><span>(修改員工姓名、權限，密碼看不到亦不可修改)</li>
  <li>刪除<br/><span>(刪除員工資料)</li>
 </ul>
 </div>
 </div>
 
 
 
 <h1>資料庫</h1>
 <div>checkList</div>
 <span>存放送審資料</span>
 <hr width="300px"/>
 <div>Elements</div>
 <span>存放庫存料件</span>
 <hr width="300px"/>
 <div>Employees</div>
 <span>存放員工資料</span>
 <hr width="300px"/>
 <div>Suppliers</div>
 <span>存放供應商資料</span>
 <hr width="300px"/>
 <div>SupplierElements</div>
 <span>存放供應商提供的料件</span>
 <hr width="300px"/>


 
 
 
