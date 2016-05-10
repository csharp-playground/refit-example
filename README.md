## ตัวอย่างการใช้งาน Refit

Refit เป็น Http Library สำหรับเรียก Rest Api โดยใช้แนวคิดเดียวกัน [Retrofit](http://square.github.io/retrofit)

องค์ประกอบของ Refit ที่ผู้ใช้ต้องประกาศมีสองส่วน คือ

- Model - เป็นโครงสร้างสำหรับเก็บข้อมูลที่ต้องการส่ง/รับ จาก Server
- Api interface - เป็น Interface ที่ประกาศ Definition ของ Rest Api ทั้งหมดที่ต้องการเรียกใช้

## ส่วน Model

```csharp
public class Track {
    public string Title { set; get; }
    public string Genre { set; get; }
}
```

## ส่วน Interface

```csharp
public interface ISoundcloudApi {
    [ Get ("/users/{user}/tracks.json?client_id={clientId}")]
    Task<Track []> GetTracks (string clientId, string user);
}
```

## การเรียกใช้

```csharp
public class SlToken {
    public string ClientId => "0be8085a39603d77fbf672a62a7929ea";
    public string UserId => "67393202";
    public string Api => "http://api.soundcloud.com";
}

[TestFixture]
public class RefitSpec {
    [Test]
    public void ShouldGetTracks () {
        var token = new SlToken ();
        var api = RestService.For<ISoundcloudApi> (token.Api);
        var tracks = api.GetTracks (token.ClientId, token.UserId).Result;

        var genesis = tracks.Where (x => x.Genre == "GENESIS");

        Assert.True (tracks.Length > 0);
        Assert.True (genesis.Count () == 1);
    }
}
```

## Link

- https://github.com/paulcbetts/refit