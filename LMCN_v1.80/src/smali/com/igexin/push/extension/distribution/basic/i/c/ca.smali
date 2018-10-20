.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/ca;
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

    const/16 v0, 0xc

    new-array v0, v0, [C

    fill-array-data v0, :array_0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a([C)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v1

    if-lez v1, :cond_0

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->d(Ljava/lang/String;)V

    :cond_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d()C

    move-result v0

    sparse-switch v0, :sswitch_data_0

    :goto_0
    return-void

    :sswitch_0
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ca;->H:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_1
    const/16 v0, 0x3e

    invoke-static {v0}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v0

    const/4 v1, 0x1

    invoke-virtual {p1, v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Ljava/lang/Character;Z)Ljava/lang/Character;

    move-result-object v0

    if-eqz v0, :cond_1

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {v0}, Ljava/lang/Character;->charValue()C

    move-result v0

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c(C)V

    goto :goto_0

    :cond_1
    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    const/16 v1, 0x26

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c(C)V

    goto :goto_0

    :sswitch_2
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ca;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_3
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    const v1, 0xfffd

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c(C)V

    goto :goto_0

    :sswitch_4
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ca;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_5
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->c(C)V

    goto :goto_0

    :array_0
    .array-data 2
        0x9s
        0xas
        0xcs
        0x20s
        0x26s
        0x3es
        0x0s
        0x22s
        0x27s
        0x3cs
        0x3ds
        0x60s
    .end array-data

    :sswitch_data_0
    .sparse-switch
        0x0 -> :sswitch_3
        0x9 -> :sswitch_0
        0xa -> :sswitch_0
        0xc -> :sswitch_0
        0x20 -> :sswitch_0
        0x22 -> :sswitch_5
        0x26 -> :sswitch_1
        0x27 -> :sswitch_5
        0x3c -> :sswitch_5
        0x3d -> :sswitch_5
        0x3e -> :sswitch_2
        0x60 -> :sswitch_5
        0xffff -> :sswitch_4
    .end sparse-switch
.end method
