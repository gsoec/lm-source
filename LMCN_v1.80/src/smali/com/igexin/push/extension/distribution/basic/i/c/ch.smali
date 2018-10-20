.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/ch;
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

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->c()C

    move-result v0

    sparse-switch v0, :sswitch_data_0

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d:Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->b:Ljava/lang/StringBuilder;

    const/4 v1, 0x2

    new-array v1, v1, [C

    fill-array-data v1, :array_0

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a([C)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :goto_0
    return-void

    :sswitch_0
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ch;->V:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_1
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->f()V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d:Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->b:Ljava/lang/StringBuilder;

    const v1, 0xfffd

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    goto :goto_0

    :sswitch_2
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ch;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_data_0
    .sparse-switch
        0x0 -> :sswitch_1
        0x2d -> :sswitch_0
        0xffff -> :sswitch_2
    .end sparse-switch

    :array_0
    .array-data 2
        0x2ds
        0x0s
    .end array-data
.end method
