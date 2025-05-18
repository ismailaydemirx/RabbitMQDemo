## 📨 RabbitMQ .NET Messaging Demo

Basit bir **Producer-Consumer** mimarisi ile RabbitMQ üzerinden mesajlaşma örneği.
`ProducerApp` rastgele mesajlar gönderir, `ConsumerApp` bu mesajları dinler ve ekrana yazdırır.

### 📂 Projeler

* `ProducerApp`: Mesajları üretir ve RabbitMQ kuyruğuna gönderir
* `ConsumerApp`: Kuyruktaki mesajları alır ve işler

### 🛠 Kullanılan Teknolojiler

* 🐇 **RabbitMQ**
* ⚙️ **.NET 9**
* 💬 **C#**
* 📦 **RabbitMQ.Client (NuGet)**

### 🚀 Çalıştırmak için

1. RabbitMQ kurulu ve çalışıyor olmalı (varsayılan `localhost`)
2. Visual Studio > Solution Properties > `Multiple startup projects` ayarlanmalı
3. Proje çalıştırıldığında iki konsol açılır:

   * Biri mesajları gönderir
   * Diğeri gelen mesajları okur
