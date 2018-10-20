.class abstract Lcom/igexin/push/extension/distribution/basic/i/c/dh;
.super Ljava/lang/Object;


# instance fields
.field b:Lcom/igexin/push/extension/distribution/basic/i/c/a;

.field c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

.field protected d:Lcom/igexin/push/extension/distribution/basic/i/b/e;

.field protected e:Lcom/igexin/push/extension/distribution/basic/i/a/b;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/igexin/push/extension/distribution/basic/i/a/b",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ">;"
        }
    .end annotation
.end field

.field protected f:Ljava/lang/String;

.field protected g:Lcom/igexin/push/extension/distribution/basic/i/c/af;

.field protected h:Lcom/igexin/push/extension/distribution/basic/i/c/ac;


# direct methods
.method constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method a(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 1

    invoke-virtual {p0, p1, p2, p3}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->b(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)V

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->w()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->d:Lcom/igexin/push/extension/distribution/basic/i/b/e;

    return-object v0
.end method

.method protected abstract a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z
.end method

.method protected b(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)V
    .locals 2

    const-string v0, "String input must not be null"

    invoke-static {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "BaseURI must not be null"

    invoke-static {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/e;

    invoke-direct {v0, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/e;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->d:Lcom/igexin/push/extension/distribution/basic/i/b/e;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-direct {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/a;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->b:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    iput-object p3, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->h:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->b:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-direct {v0, v1, p3}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/a;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->f:Ljava/lang/String;

    return-void
.end method

.method protected w()V
    .locals 2

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a()Lcom/igexin/push/extension/distribution/basic/i/c/af;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    if-ne v0, v1, :cond_0

    return-void
.end method

.method protected x()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->e:Lcom/igexin/push/extension/distribution/basic/i/a/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->getLast()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-object v0
.end method
