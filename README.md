# 🚀 Flow Blog Backend

![.NET Version](https://img.shields.io/badge/.NET-8.0-blue?style=for-the-badge)
![License](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)

**Flow Blog Backend** .NET 8.0 ilə hazırlanmış bir blog platformasının backend hissəsidir.

---

## 🔥 **İstifadə Edilən Texnologiyalar**
### **Backend Texnologiyaları**
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

---

## 📂 **Layihə Strukturu**

- `Flow.Core` - Əsas model və interfeyslər.
- `Flow.DAL` - Verilənlər bazası əməliyyatları.
- `Flow.Business` - Biznes məntiqi.
- `Flow.Infrastructure` - Yardımçı xidmətlər.
- `Flow.Presentation` - API interfeysləri.

---

## 📌 **Controllerlər**
- `SocialMediaUrlController` – Sosial media linkləri.
- `CategoryController` – Blog kateqoriyaları.
- `BlogController` – Blog postları.
- `TagController` – Blog tag-ları.
- `ColorPickerController` – Rəng seçimləri.
- `SMTPController` – E-poçt xidmətləri.
- `ContactController` – Əlaqə formaları.
- `FileUploadController` – Fayl yükləmələri.

---

## 🔧 **Quraşdırma və İstifadə**
### 📌 **Ətraf Mühitin Hazırlanması**
Aşağıdakı alətlərin quraşdırılması tələb olunur:
- **.NET SDK 8.0**
- **SQL Server**
- **Postman və ya Swagger**

### ⚙ **Konfiqurasiya**
Verilənlər bazasının bağlantısını `appsettings.json` faylında tənzimləyin:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=FlowDB;Trusted_Connection=True;"
}
```

### 🛠 **Migrasiyaların tətbiqi**
```sh
dotnet ef database update
```

### 🚀 **Layihənin İşə Salınması**
```sh
dotnet run --project Flow.Presentation
```

---

## 🤝 **Töhfə Vermək**
Töhfələr açıqdır! Fork edib PR göndərə bilərsiniz.

## 📩 **Əlaqə**
Sual və ya təklifləriniz üçün issue aça bilərsiniz! 🚀

