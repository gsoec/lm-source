.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/cy;
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

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d()C

    move-result v0

    sparse-switch v0, :sswitch_data_0

    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    iput-boolean v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cy;->an:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    :sswitch_0
    return-void

    :sswitch_1
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cy;->ak:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_2
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cy;->al:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_3
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    iput-boolean v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cy;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_4
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    iput-boolean v1, v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/cy;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    nop

    :sswitch_data_0
    .sparse-switch
        0x9 -> :sswitch_0
        0xa -> :sswitch_0
        0xc -> :sswitch_0
        0x20 -> :sswitch_0
        0x22 -> :sswitch_1
        0x27 -> :sswitch_2
        0x3e -> :sswitch_3
        0xffff -> :sswitch_4
    .end sparse-switch
.end method
