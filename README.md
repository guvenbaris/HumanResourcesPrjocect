#  Human Resources Project

İnsan kaynakları projesi, sadece Backend olarak tasarlanmıştır. Sunum katmanı olarak 
Console kullanılmıştır. Database olarak json veri dosyasında okuma işlemi yapılmıştır.

# N-Katmanlı mimari

N-Katmanlı mimari sorumlulukların ayrılması ve bağımlılıkların yönetilmesi
 için kullanılan bir yöntemdir. Her katmanın belirli bir sorumluluğu vardır.
 Daha yüksek bir katman, hizmetleri daha düşük bir katmanda kullanabilir ancak daha düşük 
 bir katman, hizmetleri daha yüksek bir katmanda kullanamaz.

Katmanlar fiziksel olarak ayrılmıştır ve ayrı makineler üzerinde çalışır.
 Bir katman başka bir katmanı doğrudan çağırabilir veya zaman uyumsuz mesajlaşmayı
  (ileti kuyruğu) kullanabilir. Her katman kendi katmanında barındırılıyor olsa da bu, 
  zorunlu değildir. Aynı katmanda birden fazla katman barındırılabilir. Katmanların
   fiziksel olarak ayrılması ölçeklenebilirliği ve esnekliği artırır, ancak ek ağ 
   iletişiminden gecikmeye de neden olur.

Geleneksel bir üç katmanlı uygulamanın bir sunum katmanı, 
orta katmanı ve veritabanı katmanı bulunur. Orta katman isteğe bağlıdır.
 Daha karmaşık uygulamalar üçten fazla katmana sahip olabilir.
