.class abstract Lcom/igexin/push/extension/distribution/basic/i/c/an;
.super Lcom/igexin/push/extension/distribution/basic/i/c/af;


# instance fields
.field protected b:Ljava/lang/String;

.field c:Z

.field d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

.field private e:Ljava/lang/String;

.field private f:Ljava/lang/String;


# direct methods
.method constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/af;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ag;)V

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c:Z

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    return-void
.end method


# virtual methods
.method a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/an;
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b:Ljava/lang/String;

    return-object p0
.end method

.method a(C)V
    .locals 1

    invoke-static {p1}, Ljava/lang/String;->valueOf(C)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b(Ljava/lang/String;)V

    return-void
.end method

.method b(C)V
    .locals 1

    invoke-static {p1}, Ljava/lang/String;->valueOf(C)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c(Ljava/lang/String;)V

    return-void
.end method

.method b(Ljava/lang/String;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b:Ljava/lang/String;

    if-nez v0, :cond_0

    :goto_0
    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b:Ljava/lang/String;

    return-void

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b:Ljava/lang/String;

    invoke-virtual {v0, p1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    goto :goto_0
.end method

.method c(C)V
    .locals 1

    invoke-static {p1}, Ljava/lang/String;->valueOf(C)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->d(Ljava/lang/String;)V

    return-void
.end method

.method c(Ljava/lang/String;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->e:Ljava/lang/String;

    if-nez v0, :cond_0

    :goto_0
    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->e:Ljava/lang/String;

    return-void

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->e:Ljava/lang/String;

    invoke-virtual {v0, p1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    goto :goto_0
.end method

.method d(Ljava/lang/String;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->f:Ljava/lang/String;

    if-nez v0, :cond_0

    :goto_0
    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->f:Ljava/lang/String;

    return-void

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->f:Ljava/lang/String;

    invoke-virtual {v0, p1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    goto :goto_0
.end method

.method m()V
    .locals 4

    const/4 v3, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->e:Ljava/lang/String;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->f:Ljava/lang/String;

    if-nez v0, :cond_0

    const-string v0, ""

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->f:Ljava/lang/String;

    :cond_0
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/a;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->e:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->f:Ljava/lang/String;

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/a;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/a;)V

    :cond_1
    iput-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->e:Ljava/lang/String;

    iput-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->f:Ljava/lang/String;

    return-void
.end method

.method n()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->e:Ljava/lang/String;

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->m()V

    :cond_0
    return-void
.end method

.method o()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->b(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b:Ljava/lang/String;

    return-object v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method p()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c:Z

    return v0
.end method

.method q()Lcom/igexin/push/extension/distribution/basic/i/b/b;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    return-object v0
.end method
