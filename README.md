# Dependency Injection
- Overview: **Dependency Injection** (DI) là một trong nhiều cách triển khai **Inversion of Control** (IOC), mà IOC là một design pattern của **Dependency inversion principle** (DIP)

>  DIP là đích đến, IOC là tầm nhìn và DI là con đường cụ thể để đến
> được đích đó.

## II. Nhắc lại về DI

### 1. Khái niệm về sự phụ thuộc (Dependency)

 Giả sử bạn có một lớp **classA**, lớp này có sử dụng một chức năng từ đối tượng lớp **classB** (classA hoạt động dựa vào classB). Lúc đó **classB** gọi là **phụ thuộc (dependency)**  _(của classA)_![Nguồn: codelearn.io](https://codelearn.io/Media/Default/Users/VuTungMinh/Template/aa.jpeg)

### 2. Dependency inversion principle (nguyên lý đảo ngược phụ thuộc)

>  Các module cấp cao không nên phụ thuộc vào các module cấp thấp. Cả 2
> nên phụ thuộc vào abstraction
> 
>  Interface (abstraction) không nên phụ thuộc vào chi tiết, mà ngược
> lại. (Các class giao tiếp với nhau thông qua interface, không phải
> thông qua implementation.)

- module (có thể là 1 project, 1 file hoặc, 1 service,...) để đơn giản ta coi 1 module là class
=> Hiểu 1 cách đơn giản, một class nên phụ thuộc vào **abstractions** (e.g interface, abstract classes) chứ không nên phụ thuộc vào **specific details** (e.g object) từ một class khác.

### 3. **Inversion of Control (IoC)**

![Nguồn: xuanthulab.com](https://xuanthulab.net/photo/ioc-4477.png)
- Ở mô hình không IoC, `Class A` khi cần chủ động tạo ra đối tượng lớp `Class B` và `Class C` (nó nắm quyền khởi tạo, điều khiển)
- Với mô hình **IoC** thì `class A` không tự khởi tạo cũng không chịu trách nhiệm quản lý `Class B`, `Class C`. Nó nhận được hai dependency này từ bên ngoài thông qua cơ chế nào đó.

### 4. Dependency injection

 Là một cách triển khai của IOC, ở đó các phụ thuộc (dependency) được tiêm vào class khi nó cần.
- Các kiểu dependency injection:
		- Inject thông qua constructor (thư viện của .Net đã hỗ trợ sẵn)
		- Inject thông qua setter
		- Inject thông qua interface

#### 4.1: DI Container
- Là công cụ quản lý và cung cấp dịch vụ cho các thành phần khác trong ứng dụng (ASP.NET Core có DI Container mặc định là **Microsoft.Extensions.DependencyInjection**)
- Cách hoạt động: Khi nhận được 1 request, DI container sẽ khởi tạo một đối tượng PageModel mới và tìm tất cả các dependency cần thiết program.cs (với .NET 6)

#### 4.2: ServiceCollection
- Là một class triển khai interface IServiceCollection cung cấp các phương thức đăng ký và quản lý các service
- VD: Bạn có thể sử dụng phương thức AddSingleton(), AddTransient() và AddScoped() để đăng ký các service

#### 4.3: Service Lifetime
- Service lifetime là các cách thức để xác định thời gian sống (lifetime) của một service được tạo ra bởi DI container.
![enter image description here](https://tedu.com.vn/uploaded/images/082019/Singleton-Service-in-ASP.NET-Core-Dependency-Injection.png)

	-  **Transient**: Thường được sử dụng cho các service có tính chất tạm thời, không lưu trữ trạng thái, không luân chuyển dữ liệu giữa các request khác nhau. 
Ví dụ: như các service để xử lý dữ liệu tạm thời, thực hiện các phép tính toán hoặc truy xuất dữ liệu theo yêu cầu.
    
	- **Scoped**: Thường được sử dụng khi bạn muốn lưu trữ trạng thái và chia sẻ dữ liệu qua các request khác nhau.
Ví dụ: lưu thông tin đăng nhập của User, sử dụng DbContext cho các service khác nhau trong cùng một 

	- **Singleton**: DI container sẽ tạo một đối tượng duy nhất và tái sử dụng nó cho mọi yêu cầu tiếp theo. Đối tượng này sẽ sống trong suốt vòng đời của ứng dụng.
    
	- **Singleton Instance**: Cũng giống như Singleton, tuy nhiên, đối tượng được tạo ra bởi DI container không phải là đối tượng mới, mà là một đối tượng đã được tạo trước đó bởi ứng dụng.
