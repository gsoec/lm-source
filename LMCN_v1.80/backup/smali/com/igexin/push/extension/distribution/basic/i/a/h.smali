.class public Lcom/igexin/push/extension/distribution/basic/i/a/h;
.super Lcom/igexin/push/extension/distribution/basic/i/a/g;

# interfaces
.implements Lcom/igexin/push/extension/distribution/basic/i/e;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/igexin/push/extension/distribution/basic/i/a/g",
        "<",
        "Lcom/igexin/push/extension/distribution/basic/i/e;",
        ">;",
        "Lcom/igexin/push/extension/distribution/basic/i/e;"
    }
.end annotation


# instance fields
.field private e:I

.field private f:Z

.field private g:Ljava/util/Collection;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Collection",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/c;",
            ">;"
        }
    .end annotation
.end field

.field private h:Z

.field private i:Z

.field private j:Lcom/igexin/push/extension/distribution/basic/i/c/ad;


# direct methods
.method private constructor <init>()V
    .locals 3

    const/4 v1, 0x0

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/g;-><init>(Lcom/igexin/push/extension/distribution/basic/i/a/f;)V

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->h:Z

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->i:Z

    const/16 v0, 0xbb8

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->e:I

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->f:Z

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->g:Ljava/util/Collection;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/d;->a:Lcom/igexin/push/extension/distribution/basic/i/d;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->b:Lcom/igexin/push/extension/distribution/basic/i/d;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->c:Ljava/util/Map;

    const-string v1, "Accept-Encoding"

    const-string v2, "gzip"

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->b()Lcom/igexin/push/extension/distribution/basic/i/c/ad;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->j:Lcom/igexin/push/extension/distribution/basic/i/c/ad;

    return-void
.end method

.method synthetic constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/a/f;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/h;-><init>()V

    return-void
.end method


# virtual methods
.method public synthetic a(I)Lcom/igexin/push/extension/distribution/basic/i/e;
    .locals 1

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/h;->b(I)Lcom/igexin/push/extension/distribution/basic/i/a/h;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic a(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    invoke-super {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/g;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic a()Ljava/net/URL;
    .locals 1

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/g;->a()Ljava/net/URL;

    move-result-object v0

    return-object v0
.end method

.method public b(I)Lcom/igexin/push/extension/distribution/basic/i/a/h;
    .locals 2

    if-ltz p1, :cond_0

    const/4 v0, 0x1

    :goto_0
    const-string v1, "Timeout milliseconds must be 0 (infinite) or greater"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(ZLjava/lang/String;)V

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->e:I

    return-object p0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public bridge synthetic b()Lcom/igexin/push/extension/distribution/basic/i/d;
    .locals 1

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/g;->b()Lcom/igexin/push/extension/distribution/basic/i/d;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic b(Ljava/lang/String;)Z
    .locals 1

    invoke-super {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/g;->b(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public bridge synthetic c()Ljava/util/Map;
    .locals 1

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/g;->c()Ljava/util/Map;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic d()Ljava/util/Map;
    .locals 1

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/g;->d()Ljava/util/Map;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic d(Ljava/lang/String;)Z
    .locals 1

    invoke-super {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/a/g;->d(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public e()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->e:I

    return v0
.end method

.method public f()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->f:Z

    return v0
.end method

.method public g()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->h:Z

    return v0
.end method

.method public h()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->i:Z

    return v0
.end method

.method public i()Ljava/util/Collection;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Collection",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/c;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->g:Ljava/util/Collection;

    return-object v0
.end method

.method public j()Lcom/igexin/push/extension/distribution/basic/i/c/ad;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/h;->j:Lcom/igexin/push/extension/distribution/basic/i/c/ad;

    return-object v0
.end method
