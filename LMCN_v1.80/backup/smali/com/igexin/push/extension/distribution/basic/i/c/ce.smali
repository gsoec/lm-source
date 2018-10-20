.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/ce;
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
    .locals 1

    const-string v0, "--"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ce;->S:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    return-void

    :cond_0
    const-string v0, "DOCTYPE"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ce;->Y:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :cond_1
    const-string v0, "[CDATA["

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_2

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ce;->ao:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :cond_2
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ce;->Q:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0
.end method
