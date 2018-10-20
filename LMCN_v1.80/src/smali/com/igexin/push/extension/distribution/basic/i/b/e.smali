.class public Lcom/igexin/push/extension/distribution/basic/i/b/e;
.super Lcom/igexin/push/extension/distribution/basic/i/b/i;


# instance fields
.field private f:Lcom/igexin/push/extension/distribution/basic/i/b/f;

.field private g:Lcom/igexin/push/extension/distribution/basic/i/b/g;


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 1

    const-string v0, "#root"

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v0

    invoke-direct {p0, v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/f;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/f;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;->f:Lcom/igexin/push/extension/distribution/basic/i/b/f;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/g;->a:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;->g:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/g;)Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;->g:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    return-object p0
.end method

.method public a()Ljava/lang/String;
    .locals 1

    const-string v0, "#document"

    return-object v0
.end method

.method public c()Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 2

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/e;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;->f:Lcom/igexin/push/extension/distribution/basic/i/b/f;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->f()Lcom/igexin/push/extension/distribution/basic/i/b/f;

    move-result-object v1

    iput-object v1, v0, Lcom/igexin/push/extension/distribution/basic/i/b/e;->f:Lcom/igexin/push/extension/distribution/basic/i/b/f;

    return-object v0
.end method

.method public synthetic clone()Ljava/lang/Object;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->c()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    return-object v0
.end method

.method public d()Lcom/igexin/push/extension/distribution/basic/i/b/f;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;->f:Lcom/igexin/push/extension/distribution/basic/i/b/f;

    return-object v0
.end method

.method public d_()Ljava/lang/String;
    .locals 1

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->v()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public e()Lcom/igexin/push/extension/distribution/basic/i/b/g;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;->g:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    return-object v0
.end method

.method public synthetic f()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->c()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    return-object v0
.end method

.method public synthetic g()Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->c()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    return-object v0
.end method
