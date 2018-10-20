.class public final Lcom/alipay/android/phone/mrpc/core/r;
.super Lcom/alipay/android/phone/mrpc/core/x;


# instance fields
.field a:Ljava/lang/String;

.field b:[B

.field c:Ljava/lang/String;

.field d:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Lorg/apache/http/Header;",
            ">;"
        }
    .end annotation
.end field

.field e:Z

.field private h:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 1

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/x;-><init>()V

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    const-string v0, "application/x-www-form-urlencoded"

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->c:Ljava/lang/String;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;[BLjava/util/ArrayList;Ljava/util/HashMap;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "[B",
            "Ljava/util/ArrayList",
            "<",
            "Lorg/apache/http/Header;",
            ">;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/x;-><init>()V

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    iput-object p2, p0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    iput-object p3, p0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    iput-object p4, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    const-string v0, "application/x-www-form-urlencoded"

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->c:Ljava/lang/String;

    return-void
.end method

.method private a(Ljava/util/ArrayList;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList",
            "<",
            "Lorg/apache/http/Header;",
            ">;)V"
        }
    .end annotation

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    return-void
.end method

.method private a(Ljava/util/Map;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    return-void
.end method

.method private a(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->e:Z

    return-void
.end method

.method private a([B)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    return-void
.end method

.method private b()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    return-object v0
.end method

.method private b(Ljava/lang/String;)Ljava/lang/String;
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    return-object p1
.end method

.method private c(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/r;->c:Ljava/lang/String;

    return-void
.end method

.method private c()[B
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    return-object v0
.end method

.method private d()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->c:Ljava/lang/String;

    return-object v0
.end method

.method private e()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList",
            "<",
            "Lorg/apache/http/Header;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    return-object v0
.end method

.method private f()Z
    .locals 1

    iget-boolean v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->e:Z

    return v0
.end method

.method private g()Ljava/lang/String;
    .locals 2

    .prologue
    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    .line 1000
    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 0
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 2000
    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    .line 0
    invoke-virtual {v1}, Ljava/lang/Object;->hashCode()I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->toHexString(I)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public final a(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    goto :goto_0
.end method

.method public final a(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    if-nez v0, :cond_0

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    :cond_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public final a(Lorg/apache/http/Header;)V
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public final equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    const/4 v1, 0x0

    if-ne p0, p1, :cond_1

    :cond_0
    :goto_0
    return v0

    :cond_1
    if-nez p1, :cond_2

    move v0, v1

    goto :goto_0

    :cond_2
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v2

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v3

    if-eq v2, v3, :cond_3

    move v0, v1

    goto :goto_0

    :cond_3
    check-cast p1, Lcom/alipay/android/phone/mrpc/core/r;

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    if-nez v2, :cond_4

    iget-object v2, p1, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    if-eqz v2, :cond_5

    move v0, v1

    goto :goto_0

    :cond_4
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    iget-object v3, p1, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    invoke-virtual {v2, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_5

    move v0, v1

    goto :goto_0

    :cond_5
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    if-nez v2, :cond_6

    iget-object v2, p1, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    if-eqz v2, :cond_0

    move v0, v1

    goto :goto_0

    :cond_6
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    iget-object v3, p1, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_0

    move v0, v1

    goto :goto_0
.end method

.method public final hashCode()I
    .locals 3

    const/4 v0, 0x1

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    if-eqz v1, :cond_0

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    const-string v2, "id"

    invoke-interface {v1, v2}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->h:Ljava/util/Map;

    const-string v1, "id"

    invoke-interface {v0, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    add-int/lit8 v0, v0, 0x1f

    :cond_0
    mul-int/lit8 v1, v0, 0x1f

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    if-nez v0, :cond_1

    const/4 v0, 0x0

    :goto_0
    add-int/2addr v0, v1

    return v0

    :cond_1
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    goto :goto_0
.end method

.method public final toString()Ljava/lang/String;
    .locals 4

    .prologue
    .line 0
    const-string v0, "Url : %s,HttpHeader: %s"

    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/Object;

    const/4 v2, 0x0

    .line 3000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 0
    aput-object v3, v1, v2

    const/4 v2, 0x1

    .line 4000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    .line 0
    aput-object v3, v1, v2

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
