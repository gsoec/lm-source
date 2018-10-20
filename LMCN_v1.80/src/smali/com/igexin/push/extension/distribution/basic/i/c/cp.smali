.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/cp;
.super Lcom/igexin/push/extension/distribution/basic/i/c/ar;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ar;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/as;)V

    return-void
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/aq;Lcom/igexin/push/extension/distribution/basic/i/c/a;)V
    .locals 2

    const/4 v1, 0x1

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    iput-boolean v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cp;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    return-void

    :cond_0
    const/4 v0, 0x4

    new-array v0, v0, [C

    fill-array-data v0, :array_0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b([C)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->f()V

    goto :goto_0

    :cond_1
    const/16 v0, 0x3e

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b(C)Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cp;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :cond_2
    const-string v0, "PUBLIC"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_3

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cp;->ac:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :cond_3
    const-string v0, "SYSTEM"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_4

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cp;->ai:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :cond_4
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    iput-boolean v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cp;->an:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    nop

    :array_0
    .array-data 2
        0x9s
        0xas
        0xcs
        0x20s
    .end array-data
.end method
