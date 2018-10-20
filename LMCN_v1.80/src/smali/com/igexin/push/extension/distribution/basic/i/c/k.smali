.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/k;
.super Lcom/igexin/push/extension/distribution/basic/i/c/c;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/d;)V

    return-void
.end method

.method private b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 1

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    return v0
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 6

    const/4 v1, 0x1

    const/4 v0, 0x0

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/i/c/t;->a:[I

    iget-object v3, p1, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->ordinal()I

    move-result v3

    aget v2, v2, v3

    packed-switch v2, :pswitch_data_0

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/k;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    :cond_0
    :goto_0
    return v0

    :pswitch_0
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->k()Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->m()Ljava/lang/String;

    move-result-object v3

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :cond_1
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V

    :cond_2
    :goto_1
    move v0, v1

    goto :goto_0

    :pswitch_1
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V

    goto :goto_1

    :pswitch_2
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :pswitch_3
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->e()Lcom/igexin/push/extension/distribution/basic/i/c/am;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v3

    const-string v4, "html"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_3

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/k;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    goto :goto_0

    :cond_3
    const-string v4, "option"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_4

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v3, "option"

    invoke-direct {v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_1

    :cond_4
    const-string v4, "optgroup"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_7

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v3, "option"

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_6

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v3, "option"

    invoke-direct {v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_5
    :goto_2
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_1

    :cond_6
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v3, "optgroup"

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_5

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v3, "optgroup"

    invoke-direct {v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    goto :goto_2

    :cond_7
    const-string v4, "select"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_8

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "select"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_0

    :cond_8
    const/4 v4, 0x3

    new-array v4, v4, [Ljava/lang/String;

    const-string v5, "input"

    aput-object v5, v4, v0

    const-string v5, "keygen"

    aput-object v5, v4, v1

    const/4 v1, 0x2

    const-string v5, "textarea"

    aput-object v5, v4, v1

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_9

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const-string v1, "select"

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "select"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_0

    :cond_9
    const-string v0, "script"

    invoke-virtual {v3, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_a

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/k;->d:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    goto/16 :goto_0

    :cond_a
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/k;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_0

    :pswitch_4
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v2

    const-string v3, "optgroup"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_d

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v2, "option"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_b

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_b

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v2, "optgroup"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_b

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v2, "option"

    invoke-direct {v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_b
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v2, "optgroup"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_c

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_1

    :cond_c
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_1

    :cond_d
    const-string v3, "option"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_f

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v2, "option"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_e

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_1

    :cond_e
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_1

    :cond_f
    const-string v3, "select"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_11

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i(Ljava/lang/String;)Z

    move-result v3

    if-nez v3, :cond_10

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_10
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->m()V

    goto/16 :goto_1

    :cond_11
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/k;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_0

    :pswitch_5
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v2, "html"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_2

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_1

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_1
        :pswitch_2
        :pswitch_3
        :pswitch_4
        :pswitch_0
        :pswitch_5
    .end packed-switch
.end method
