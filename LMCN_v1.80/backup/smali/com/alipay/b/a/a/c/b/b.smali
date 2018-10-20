.class public final Lcom/alipay/b/a/a/c/b/b;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/alipay/b/a/a/c/b/a;


# static fields
.field private static a:Lcom/alipay/b/a/a/c/b/a;

.field private static b:Lcom/alipay/b/a/a/c/a;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const/4 v0, 0x0

    sput-object v0, Lcom/alipay/b/a/a/c/b/b;->a:Lcom/alipay/b/a/a/c/b/a;

    sput-object v0, Lcom/alipay/b/a/a/c/b/b;->b:Lcom/alipay/b/a/a/c/a;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static a(Landroid/content/Context;Ljava/lang/String;)Lcom/alipay/b/a/a/c/b/a;
    .locals 2

    const/4 v0, 0x0

    if-nez p0, :cond_0

    :goto_0
    return-object v0

    :cond_0
    sget-object v1, Lcom/alipay/b/a/a/c/b/b;->a:Lcom/alipay/b/a/a/c/b/a;

    if-nez v1, :cond_1

    if-nez p0, :cond_2

    :goto_1
    sput-object v0, Lcom/alipay/b/a/a/c/b/b;->b:Lcom/alipay/b/a/a/c/a;

    new-instance v0, Lcom/alipay/b/a/a/c/b/b;

    invoke-direct {v0}, Lcom/alipay/b/a/a/c/b/b;-><init>()V

    sput-object v0, Lcom/alipay/b/a/a/c/b/b;->a:Lcom/alipay/b/a/a/c/b/a;

    :cond_1
    sget-object v0, Lcom/alipay/b/a/a/c/b/b;->a:Lcom/alipay/b/a/a/c/b/a;

    goto :goto_0

    :cond_2
    invoke-static {p0, p1}, Lcom/alipay/b/a/a/c/b;->a(Landroid/content/Context;Ljava/lang/String;)Lcom/alipay/b/a/a/c/b;

    move-result-object v0

    goto :goto_1
.end method


# virtual methods
.method public final a(Lcom/alipay/b/a/a/c/a/d;)Lcom/alipay/b/a/a/c/a/c;
    .locals 4

    .prologue
    .line 0
    new-instance v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;

    invoke-direct {v1}, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;-><init>()V

    .line 1000
    iget-object v0, p1, Lcom/alipay/b/a/a/c/a/d;->a:Ljava/lang/String;

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 0
    iput-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->c:Ljava/lang/String;

    const-string v0, "8"

    iput-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->b:Ljava/lang/String;

    const-string v0, "1"

    iput-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->a:Ljava/lang/String;

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->d:Ljava/util/Map;

    iget-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->d:Ljava/util/Map;

    const-string v2, "apdid"

    .line 2000
    iget-object v3, p1, Lcom/alipay/b/a/a/c/a/d;->b:Ljava/lang/String;

    invoke-static {v3}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 0
    invoke-interface {v0, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    iget-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->d:Ljava/util/Map;

    const-string v2, "apdidToken"

    .line 3000
    iget-object v3, p1, Lcom/alipay/b/a/a/c/a/d;->c:Ljava/lang/String;

    invoke-static {v3}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 0
    invoke-interface {v0, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    iget-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->d:Ljava/util/Map;

    const-string v2, "umidToken"

    .line 4000
    iget-object v3, p1, Lcom/alipay/b/a/a/c/a/d;->d:Ljava/lang/String;

    invoke-static {v3}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 0
    invoke-interface {v0, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    iget-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->d:Ljava/util/Map;

    const-string v2, "dynamicKey"

    .line 5000
    iget-object v3, p1, Lcom/alipay/b/a/a/c/a/d;->e:Ljava/lang/String;

    .line 0
    invoke-interface {v0, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 6000
    iget-object v0, p1, Lcom/alipay/b/a/a/c/a/d;->f:Ljava/util/Map;

    if-nez v0, :cond_0

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 0
    :goto_0
    iput-object v0, v1, Lcom/alipay/tscenter/biz/rpc/report/general/model/a;->e:Ljava/util/Map;

    sget-object v0, Lcom/alipay/b/a/a/c/b/b;->b:Lcom/alipay/b/a/a/c/a;

    invoke-interface {v0, v1}, Lcom/alipay/b/a/a/c/a;->a(Lcom/alipay/tscenter/biz/rpc/report/general/model/a;)Lcom/alipay/tscenter/biz/rpc/report/general/model/b;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/b/a/a/c/a/b;->a(Lcom/alipay/tscenter/biz/rpc/report/general/model/b;)Lcom/alipay/b/a/a/c/a/c;

    move-result-object v0

    return-object v0

    .line 6000
    :cond_0
    iget-object v0, p1, Lcom/alipay/b/a/a/c/a/d;->f:Ljava/util/Map;

    goto :goto_0
.end method

.method public final a(Ljava/lang/String;)Z
    .locals 1

    sget-object v0, Lcom/alipay/b/a/a/c/b/b;->b:Lcom/alipay/b/a/a/c/a;

    invoke-interface {v0, p1}, Lcom/alipay/b/a/a/c/a;->a(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method
