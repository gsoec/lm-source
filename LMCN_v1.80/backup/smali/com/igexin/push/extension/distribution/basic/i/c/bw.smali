.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/bw;
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

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->N:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    :sswitch_0
    return-void

    :sswitch_1
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->L:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_2
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->N:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_3
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->M:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_4
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    const v1, 0xfffd

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c(C)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->N:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_5
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_6
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_7
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c(C)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bw;->N:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    nop

    :sswitch_data_0
    .sparse-switch
        0x0 -> :sswitch_4
        0x9 -> :sswitch_0
        0xa -> :sswitch_0
        0xc -> :sswitch_0
        0x20 -> :sswitch_0
        0x22 -> :sswitch_1
        0x26 -> :sswitch_2
        0x27 -> :sswitch_3
        0x3c -> :sswitch_7
        0x3d -> :sswitch_7
        0x3e -> :sswitch_6
        0x60 -> :sswitch_7
        0xffff -> :sswitch_5
    .end sparse-switch
.end method
