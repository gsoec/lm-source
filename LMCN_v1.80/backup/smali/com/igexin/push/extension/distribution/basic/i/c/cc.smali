.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/cc;
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

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d()C

    move-result v0

    sparse-switch v0, :sswitch_data_0

    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cc;->H:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    return-void

    :sswitch_0
    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    const/4 v1, 0x1

    iput-boolean v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c:Z

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cc;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_1
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cc;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    nop

    :sswitch_data_0
    .sparse-switch
        0x3e -> :sswitch_0
        0xffff -> :sswitch_1
    .end sparse-switch
.end method
