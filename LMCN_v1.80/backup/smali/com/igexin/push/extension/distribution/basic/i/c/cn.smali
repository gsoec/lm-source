.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/cn;
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

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->n()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cn;->aa:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    :sswitch_0
    return-void

    :cond_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d()C

    move-result v0

    sparse-switch v0, :sswitch_data_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f()V

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    iget-object v1, v1, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->b:Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cn;->aa:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_1
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->b:Ljava/lang/StringBuilder;

    const v1, 0xfffd

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cn;->aa:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_2
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f()V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    const/4 v1, 0x1

    iput-boolean v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cn;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    nop

    :sswitch_data_0
    .sparse-switch
        0x0 -> :sswitch_1
        0x9 -> :sswitch_0
        0xa -> :sswitch_0
        0xc -> :sswitch_0
        0x20 -> :sswitch_0
        0xffff -> :sswitch_2
    .end sparse-switch
.end method
