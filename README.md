# AspCoreMarch2022
Lop ASP.NET Core KG 17/03/2022

## Buổi 12 (16/04/2022) - Layout
* Razor layout (template chung)
	* 1 cái duy nhất RenderBody()
	* n cái RenderSection()

* PartialView: view nhỏ hơn
	* Gọi:
	```cs
	@await Html.PartialAsync("Ten_Partial_view")
	```
* Area
	* Chú ý thêm phần routing cho area ở method Configure() file StartUp.cs
	* Tạo Controller nhớ thêm property [Area("area_name")]
	* Để view render được thuộc tính dạng asp-* thí nhớ trong _ViewImport.cshtml chèn lệnh
		```cs
		@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
		```