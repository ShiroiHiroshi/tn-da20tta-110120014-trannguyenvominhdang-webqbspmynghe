# tn-da20tta-110120014-trannguyenvominhdang-webqbspmynghe

## Tên đề tài
Website quảng bá sản phẩm thủ công mỹ nghệ

## Mục tiêu
Xây dựng một website đáp ứng, thân thiện với người dùng để quảng bá và giới thiệu các sản phẩm thủ công mỹ nghệ từ các nghệ nhân và doanh nghiệp sản xuất trong khu vực địa phương.

## Kiến trúc
Mô hình MVC

## Các phần mềm cần thiết để triển khai
- Visual Studio
- SQL Server

## Cách thức chạy chương trình
1. **Bước 1:** Git clone các tệp file về máy.
2. **Bước 2:** Thực hiện tạo cơ sở dữ liệu từ file `WebsiteQuangBaMyNghe.sql`.
3. **Bước 3:** Mở ứng dụng Visual Studio và mở folder `WebsiteQuangBaMyNghe`.
4. **Bước 4:** Trên thanh công cụ chọn `Tools > NuGet Package Manager > Package Manager Console`.
5. **Bước 5:** Khi ấn vào Package Manager Console, hệ thống sẽ hiển thị terminal cho phép nhập lệnh từ bàn phím. Thực hiện nhập các lệnh sau đây:
    - `enable-migrations`
    - `add-migration <Tên>`
    
    Sau khi chạy đoạn code này, hệ thống sẽ tạo ra file kết nối với cơ sở dữ liệu. Nếu bảng cơ sở dữ liệu đã tồn tại, bạn chỉ cần thực hiện xóa các dòng tạo bảng trên file.
    - `update-database`
6. **Bước 6:** Thực hiện chạy chương trình, hệ thống sẽ mở giao diện website cho phép bạn tương tác các chức năng trên trang web.
