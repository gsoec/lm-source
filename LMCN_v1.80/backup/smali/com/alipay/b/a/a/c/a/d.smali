.class public final Lcom/alipay/b/a/a/c/a/d;
.super Ljava/lang/Object;


# instance fields
.field public a:Ljava/lang/String;

.field public b:Ljava/lang/String;

.field public c:Ljava/lang/String;

.field public d:Ljava/lang/String;

.field public e:Ljava/lang/String;

.field public f:Ljava/util/Map;
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

.field public g:Ljava/lang/String;

.field public h:Ljava/lang/String;

.field public i:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private a()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/b/a/a/c/a/d;->a:Ljava/lang/String;

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private a(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->a:Ljava/lang/String;

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

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->f:Ljava/util/Map;

    return-void
.end method

.method private b()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/b/a/a/c/a/d;->b:Ljava/lang/String;

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private b(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->b:Ljava/lang/String;

    return-void
.end method

.method private c()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/b/a/a/c/a/d;->c:Ljava/lang/String;

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private c(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->c:Ljava/lang/String;

    return-void
.end method

.method private d()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/b/a/a/c/a/d;->d:Ljava/lang/String;

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private d(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->d:Ljava/lang/String;

    return-void
.end method

.method private e()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/alipay/b/a/a/c/a/d;->f:Ljava/util/Map;

    if-nez v0, :cond_0

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/alipay/b/a/a/c/a/d;->f:Ljava/util/Map;

    goto :goto_0
.end method

.method private e(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->e:Ljava/lang/String;

    return-void
.end method

.method private f()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/b/a/a/c/a/d;->e:Ljava/lang/String;

    return-object v0
.end method

.method private f(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->g:Ljava/lang/String;

    return-void
.end method

.method private g(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->h:Ljava/lang/String;

    return-void
.end method

.method private h(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/b/a/a/c/a/d;->i:Ljava/lang/String;

    return-void
.end method
