.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/y;
.super Lcom/igexin/push/extension/distribution/basic/i/c/c;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/d;)V

    return-void
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 12

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/t;->a:[I

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_0

    :cond_0
    :goto_0
    const/4 v0, 0x1

    :goto_1
    return v0

    :pswitch_0
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->k()Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->m()Ljava/lang/String;

    move-result-object v1

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto :goto_1

    :cond_1
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v1

    if-eqz v1, :cond_2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V

    goto :goto_0

    :cond_2
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    goto :goto_0

    :pswitch_1
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V

    goto :goto_0

    :pswitch_2
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto :goto_1

    :pswitch_3
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->e()Lcom/igexin/push/extension/distribution/basic/i/c/am;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v0

    const-string v1, "html"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_4

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i()Lcom/igexin/push/extension/distribution/basic/i/a/b;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->getFirst()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->q()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_3
    :goto_2
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igexin/push/extension/distribution/basic/i/b/a;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/a;->a()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->e(Ljava/lang/String;)Z

    move-result v3

    if-nez v3, :cond_3

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v3

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/a;)V

    goto :goto_2

    :cond_4
    const/16 v1, 0xa

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "base"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "basefont"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "bgsound"

    aput-object v4, v1, v3

    const/4 v3, 0x3

    const-string v4, "command"

    aput-object v4, v1, v3

    const/4 v3, 0x4

    const-string v4, "link"

    aput-object v4, v1, v3

    const/4 v3, 0x5

    const-string v4, "meta"

    aput-object v4, v1, v3

    const/4 v3, 0x6

    const-string v4, "noframes"

    aput-object v4, v1, v3

    const/4 v3, 0x7

    const-string v4, "script"

    aput-object v4, v1, v3

    const/16 v3, 0x8

    const-string v4, "style"

    aput-object v4, v1, v3

    const/16 v3, 0x9

    const-string v4, "title"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_5

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/y;->d:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    goto/16 :goto_1

    :cond_5
    const-string v1, "body"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_9

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i()Lcom/igexin/push/extension/distribution/basic/i/a/b;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/LinkedList;->size()I

    move-result v0

    const/4 v3, 0x1

    if-eq v0, v3, :cond_6

    invoke-virtual {v1}, Ljava/util/LinkedList;->size()I

    move-result v0

    const/4 v3, 0x2

    if-le v0, v3, :cond_7

    const/4 v0, 0x1

    invoke-virtual {v1, v0}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v3, "body"

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_7

    :cond_6
    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_7
    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    const/4 v0, 0x1

    invoke-virtual {v1, v0}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->q()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_8
    :goto_3
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igexin/push/extension/distribution/basic/i/b/a;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/a;->a()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->e(Ljava/lang/String;)Z

    move-result v3

    if-nez v3, :cond_8

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v3

    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/a;)V

    goto :goto_3

    :cond_9
    const-string v1, "frameset"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_f

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i()Lcom/igexin/push/extension/distribution/basic/i/a/b;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/LinkedList;->size()I

    move-result v0

    const/4 v3, 0x1

    if-eq v0, v3, :cond_a

    invoke-virtual {v1}, Ljava/util/LinkedList;->size()I

    move-result v0

    const/4 v3, 0x2

    if-le v0, v3, :cond_b

    const/4 v0, 0x1

    invoke-virtual {v1, v0}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v3, "body"

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_b

    :cond_a
    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_b
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d()Z

    move-result v0

    if-nez v0, :cond_c

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_c
    const/4 v0, 0x1

    invoke-virtual {v1, v0}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v3

    if-eqz v3, :cond_d

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->A()V

    :cond_d
    :goto_4
    invoke-virtual {v1}, Ljava/util/LinkedList;->size()I

    move-result v0

    const/4 v3, 0x1

    if-le v0, v3, :cond_e

    invoke-virtual {v1}, Ljava/util/LinkedList;->removeLast()Ljava/lang/Object;

    goto :goto_4

    :cond_e
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/y;->s:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_f
    const/16 v1, 0x16

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "address"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "article"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "aside"

    aput-object v4, v1, v3

    const/4 v3, 0x3

    const-string v4, "blockquote"

    aput-object v4, v1, v3

    const/4 v3, 0x4

    const-string v4, "center"

    aput-object v4, v1, v3

    const/4 v3, 0x5

    const-string v4, "details"

    aput-object v4, v1, v3

    const/4 v3, 0x6

    const-string v4, "dir"

    aput-object v4, v1, v3

    const/4 v3, 0x7

    const-string v4, "div"

    aput-object v4, v1, v3

    const/16 v3, 0x8

    const-string v4, "dl"

    aput-object v4, v1, v3

    const/16 v3, 0x9

    const-string v4, "fieldset"

    aput-object v4, v1, v3

    const/16 v3, 0xa

    const-string v4, "figcaption"

    aput-object v4, v1, v3

    const/16 v3, 0xb

    const-string v4, "figure"

    aput-object v4, v1, v3

    const/16 v3, 0xc

    const-string v4, "footer"

    aput-object v4, v1, v3

    const/16 v3, 0xd

    const-string v4, "header"

    aput-object v4, v1, v3

    const/16 v3, 0xe

    const-string v4, "hgroup"

    aput-object v4, v1, v3

    const/16 v3, 0xf

    const-string v4, "menu"

    aput-object v4, v1, v3

    const/16 v3, 0x10

    const-string v4, "nav"

    aput-object v4, v1, v3

    const/16 v3, 0x11

    const-string v4, "ol"

    aput-object v4, v1, v3

    const/16 v3, 0x12

    const-string v4, "p"

    aput-object v4, v1, v3

    const/16 v3, 0x13

    const-string v4, "section"

    aput-object v4, v1, v3

    const/16 v3, 0x14

    const-string v4, "summary"

    aput-object v4, v1, v3

    const/16 v3, 0x15

    const-string v4, "ul"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_11

    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_10

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_10
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :cond_11
    const/4 v1, 0x6

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "h1"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "h2"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "h3"

    aput-object v4, v1, v3

    const/4 v3, 0x3

    const-string v4, "h4"

    aput-object v4, v1, v3

    const/4 v3, 0x4

    const-string v4, "h5"

    aput-object v4, v1, v3

    const/4 v3, 0x5

    const-string v4, "h6"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_14

    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_12

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_12
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x6

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "h1"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "h2"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "h3"

    aput-object v4, v1, v3

    const/4 v3, 0x3

    const-string v4, "h4"

    aput-object v4, v1, v3

    const/4 v3, 0x4

    const-string v4, "h5"

    aput-object v4, v1, v3

    const/4 v3, 0x5

    const-string v4, "h6"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_13

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    :cond_13
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :cond_14
    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "pre"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "listing"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_16

    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_15

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_15
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    goto/16 :goto_0

    :cond_16
    const-string v1, "form"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_19

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_17

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_17
    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_18

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_18
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    goto/16 :goto_0

    :cond_19
    const-string v1, "li"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1e

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i()Lcom/igexin/push/extension/distribution/basic/i/a/b;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/LinkedList;->size()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    move v1, v0

    :goto_5
    if-lez v1, :cond_1a

    invoke-virtual {v3, v1}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v4

    const-string v5, "li"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1c

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "li"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_1a
    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1b

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_1b
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :cond_1c
    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v4

    if-eqz v4, :cond_1d

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const/4 v4, 0x3

    new-array v4, v4, [Ljava/lang/String;

    const/4 v5, 0x0

    const-string v6, "address"

    aput-object v6, v4, v5

    const/4 v5, 0x1

    const-string v6, "div"

    aput-object v6, v4, v5

    const/4 v5, 0x2

    const-string v6, "p"

    aput-object v6, v4, v5

    invoke-static {v0, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1a

    :cond_1d
    add-int/lit8 v0, v1, -0x1

    move v1, v0

    goto :goto_5

    :cond_1e
    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "dd"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "dt"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_23

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i()Lcom/igexin/push/extension/distribution/basic/i/a/b;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/LinkedList;->size()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    move v1, v0

    :goto_6
    if-lez v1, :cond_1f

    invoke-virtual {v3, v1}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v4

    const/4 v5, 0x2

    new-array v5, v5, [Ljava/lang/String;

    const/4 v6, 0x0

    const-string v7, "dd"

    aput-object v7, v5, v6

    const/4 v6, 0x1

    const-string v7, "dt"

    aput-object v7, v5, v6

    invoke-static {v4, v5}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_21

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_1f
    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_20

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_20
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :cond_21
    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v4

    if-eqz v4, :cond_22

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const/4 v4, 0x3

    new-array v4, v4, [Ljava/lang/String;

    const/4 v5, 0x0

    const-string v6, "address"

    aput-object v6, v4, v5

    const/4 v5, 0x1

    const-string v6, "div"

    aput-object v6, v4, v5

    const/4 v5, 0x2

    const-string v6, "p"

    aput-object v6, v4, v5

    invoke-static {v0, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1f

    :cond_22
    add-int/lit8 v0, v1, -0x1

    move v1, v0

    goto :goto_6

    :cond_23
    const-string v1, "plaintext"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_25

    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_24

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_24
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v0, p2, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/ar;->g:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto/16 :goto_0

    :cond_25
    const-string v1, "button"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_27

    const-string v0, "button"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_26

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "button"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    goto/16 :goto_0

    :cond_26
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    goto/16 :goto_0

    :cond_27
    const-string v1, "a"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_29

    const-string v0, "a"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_28

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "a"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    const-string v0, "a"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_28

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    :cond_28
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    goto/16 :goto_0

    :cond_29
    const/16 v1, 0xc

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "b"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "big"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "code"

    aput-object v4, v1, v3

    const/4 v3, 0x3

    const-string v4, "em"

    aput-object v4, v1, v3

    const/4 v3, 0x4

    const-string v4, "font"

    aput-object v4, v1, v3

    const/4 v3, 0x5

    const-string v4, "i"

    aput-object v4, v1, v3

    const/4 v3, 0x6

    const-string v4, "s"

    aput-object v4, v1, v3

    const/4 v3, 0x7

    const-string v4, "small"

    aput-object v4, v1, v3

    const/16 v3, 0x8

    const-string v4, "strike"

    aput-object v4, v1, v3

    const/16 v3, 0x9

    const-string v4, "strong"

    aput-object v4, v1, v3

    const/16 v3, 0xa

    const-string v4, "tt"

    aput-object v4, v1, v3

    const/16 v3, 0xb

    const-string v4, "u"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2a

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    goto/16 :goto_0

    :cond_2a
    const-string v1, "nobr"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2c

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    const-string v0, "nobr"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_2b

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "nobr"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    :cond_2b
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    goto/16 :goto_0

    :cond_2c
    const/4 v1, 0x3

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "applet"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "marquee"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "object"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2d

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->v()V

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    goto/16 :goto_0

    :cond_2d
    const-string v1, "table"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2f

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->e()Lcom/igexin/push/extension/distribution/basic/i/b/g;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/b/g;->b:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    if-eq v0, v1, :cond_2e

    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_2e

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_2e
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/y;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_2f
    const/4 v1, 0x6

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "area"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "br"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "embed"

    aput-object v4, v1, v3

    const/4 v3, 0x3

    const-string v4, "img"

    aput-object v4, v1, v3

    const/4 v3, 0x4

    const-string v4, "keygen"

    aput-object v4, v1, v3

    const/4 v3, 0x5

    const-string v4, "wbr"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_30

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    goto/16 :goto_0

    :cond_30
    const-string v1, "input"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_31

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    const-string v1, "type"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "hidden"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    goto/16 :goto_0

    :cond_31
    const/4 v1, 0x3

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "param"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "source"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "track"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_32

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :cond_32
    const-string v1, "hr"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_34

    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_33

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_33
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    goto/16 :goto_0

    :cond_34
    const-string v1, "image"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_35

    const-string v0, "img"

    invoke-virtual {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_1

    :cond_35
    const-string v1, "isindex"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_3b

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_36

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_36
    iget-object v0, p2, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b()V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "form"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    iget-object v0, v2, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "action"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_37

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    const-string v1, "action"

    iget-object v3, v2, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v4, "action"

    invoke-virtual {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v1, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    :cond_37
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "hr"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "label"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    iget-object v0, v2, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "prompt"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_39

    iget-object v0, v2, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "prompt"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    :goto_7
    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    invoke-direct {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-direct {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;-><init>()V

    iget-object v0, v2, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_38
    :goto_8
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_3a

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/a;->a()Ljava/lang/String;

    move-result-object v3

    const/4 v4, 0x3

    new-array v4, v4, [Ljava/lang/String;

    const/4 v5, 0x0

    const-string v6, "name"

    aput-object v6, v4, v5

    const/4 v5, 0x1

    const-string v6, "action"

    aput-object v6, v4, v5

    const/4 v5, 0x2

    const-string v6, "prompt"

    aput-object v6, v4, v5

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v3

    if-nez v3, :cond_38

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/a;)V

    goto :goto_8

    :cond_39
    const-string v0, "This is a searchable index. Enter search keywords: "

    goto :goto_7

    :cond_3a
    const-string v0, "name"

    const-string v2, "isindex"

    invoke-virtual {v1, v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v2, "input"

    invoke-direct {v0, v2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "label"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "hr"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "form"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    goto/16 :goto_0

    :cond_3b
    const-string v1, "textarea"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_3c

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v0, p2, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/ar;->c:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b()V

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/y;->h:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_3c
    const-string v1, "xmp"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_3e

    const-string v0, "p"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_3d

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "p"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_3d
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    invoke-static {v2, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;Lcom/igexin/push/extension/distribution/basic/i/c/b;)V

    goto/16 :goto_0

    :cond_3e
    const-string v1, "iframe"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_3f

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    invoke-static {v2, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;Lcom/igexin/push/extension/distribution/basic/i/c/b;)V

    goto/16 :goto_0

    :cond_3f
    const-string v1, "noembed"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_40

    invoke-static {v2, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;Lcom/igexin/push/extension/distribution/basic/i/c/b;)V

    goto/16 :goto_0

    :cond_40
    const-string v1, "select"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_43

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    const/4 v0, 0x0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a()Lcom/igexin/push/extension/distribution/basic/i/c/c;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/y;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_41

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/y;->k:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_41

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/y;->m:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_41

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/y;->n:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_41

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/y;->o:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_42

    :cond_41
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/y;->q:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_42
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/y;->p:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_43
    const-string v1, "optgroup"

    const/4 v3, 0x1

    new-array v3, v3, [Ljava/lang/String;

    const/4 v4, 0x0

    const-string v5, "option"

    aput-object v5, v3, v4

    invoke-static {v1, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_45

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v1, "option"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_44

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "option"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    :cond_44
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :cond_45
    const-string v1, "rp"

    const/4 v3, 0x1

    new-array v3, v3, [Ljava/lang/String;

    const/4 v4, 0x0

    const-string v5, "rt"

    aput-object v5, v3, v4

    invoke-static {v1, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_47

    const-string v0, "ruby"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->s()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const-string v1, "ruby"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_46

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const-string v0, "ruby"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d(Ljava/lang/String;)V

    :cond_46
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :cond_47
    const-string v1, "math"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_48

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v0, p2, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b()V

    goto/16 :goto_0

    :cond_48
    const-string v1, "svg"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_49

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v0, p2, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b()V

    goto/16 :goto_0

    :cond_49
    const/16 v1, 0xb

    new-array v1, v1, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "caption"

    aput-object v4, v1, v3

    const/4 v3, 0x1

    const-string v4, "col"

    aput-object v4, v1, v3

    const/4 v3, 0x2

    const-string v4, "colgroup"

    aput-object v4, v1, v3

    const/4 v3, 0x3

    const-string v4, "frame"

    aput-object v4, v1, v3

    const/4 v3, 0x4

    const-string v4, "head"

    aput-object v4, v1, v3

    const/4 v3, 0x5

    const-string v4, "tbody"

    aput-object v4, v1, v3

    const/4 v3, 0x6

    const-string v4, "td"

    aput-object v4, v1, v3

    const/4 v3, 0x7

    const-string v4, "tfoot"

    aput-object v4, v1, v3

    const/16 v3, 0x8

    const-string v4, "th"

    aput-object v4, v1, v3

    const/16 v3, 0x9

    const-string v4, "thead"

    aput-object v4, v1, v3

    const/16 v3, 0xa

    const-string v4, "tr"

    aput-object v4, v1, v3

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_4a

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_4a
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->t()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_0

    :pswitch_4
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v7

    const-string v1, "body"

    invoke-virtual {v7, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_4c

    const-string v0, "body"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_4b

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_4b
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/y;->r:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_4c
    const-string v1, "html"

    invoke-virtual {v7, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_4d

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v2, "body"

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_1

    :cond_4d
    const/16 v1, 0x18

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    const-string v3, "address"

    aput-object v3, v1, v2

    const/4 v2, 0x1

    const-string v3, "article"

    aput-object v3, v1, v2

    const/4 v2, 0x2

    const-string v3, "aside"

    aput-object v3, v1, v2

    const/4 v2, 0x3

    const-string v3, "blockquote"

    aput-object v3, v1, v2

    const/4 v2, 0x4

    const-string v3, "button"

    aput-object v3, v1, v2

    const/4 v2, 0x5

    const-string v3, "center"

    aput-object v3, v1, v2

    const/4 v2, 0x6

    const-string v3, "details"

    aput-object v3, v1, v2

    const/4 v2, 0x7

    const-string v3, "dir"

    aput-object v3, v1, v2

    const/16 v2, 0x8

    const-string v3, "div"

    aput-object v3, v1, v2

    const/16 v2, 0x9

    const-string v3, "dl"

    aput-object v3, v1, v2

    const/16 v2, 0xa

    const-string v3, "fieldset"

    aput-object v3, v1, v2

    const/16 v2, 0xb

    const-string v3, "figcaption"

    aput-object v3, v1, v2

    const/16 v2, 0xc

    const-string v3, "figure"

    aput-object v3, v1, v2

    const/16 v2, 0xd

    const-string v3, "footer"

    aput-object v3, v1, v2

    const/16 v2, 0xe

    const-string v3, "header"

    aput-object v3, v1, v2

    const/16 v2, 0xf

    const-string v3, "hgroup"

    aput-object v3, v1, v2

    const/16 v2, 0x10

    const-string v3, "listing"

    aput-object v3, v1, v2

    const/16 v2, 0x11

    const-string v3, "menu"

    aput-object v3, v1, v2

    const/16 v2, 0x12

    const-string v3, "nav"

    aput-object v3, v1, v2

    const/16 v2, 0x13

    const-string v3, "ol"

    aput-object v3, v1, v2

    const/16 v2, 0x14

    const-string v3, "pre"

    aput-object v3, v1, v2

    const/16 v2, 0x15

    const-string v3, "section"

    aput-object v3, v1, v2

    const/16 v2, 0x16

    const-string v3, "summary"

    aput-object v3, v1, v2

    const/16 v2, 0x17

    const-string v3, "ul"

    aput-object v3, v1, v2

    invoke-static {v7, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_50

    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_4e

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_4e
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->s()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_4f

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_4f
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    goto/16 :goto_0

    :cond_50
    const-string v1, "form"

    invoke-virtual {v7, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_54

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    const/4 v1, 0x0

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    if-eqz v0, :cond_51

    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_52

    :cond_51
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_52
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->s()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_53

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_53
    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    goto/16 :goto_0

    :cond_54
    const-string v1, "p"

    invoke-virtual {v7, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_57

    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->g(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_55

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    invoke-direct {v1, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_1

    :cond_55
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_56

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_56
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    goto/16 :goto_0

    :cond_57
    const-string v0, "li"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_5a

    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_58

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_58
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_59

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_59
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    goto/16 :goto_0

    :cond_5a
    const/4 v0, 0x2

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "dd"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "dt"

    aput-object v2, v0, v1

    invoke-static {v7, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_5d

    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_5b

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_5b
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_5c

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_5c
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    goto/16 :goto_0

    :cond_5d
    const/4 v0, 0x6

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "h1"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "h2"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "h3"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "h4"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, "h5"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "h6"

    aput-object v2, v0, v1

    invoke-static {v7, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_60

    const/4 v0, 0x6

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "h1"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "h2"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "h3"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "h4"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, "h5"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "h6"

    aput-object v2, v0, v1

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b([Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_5e

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_5e
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_5f

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_5f
    const/4 v0, 0x6

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "h1"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "h2"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "h3"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "h4"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, "h5"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "h6"

    aput-object v2, v0, v1

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a([Ljava/lang/String;)V

    goto/16 :goto_0

    :cond_60
    const-string v0, "sarcasm"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_61

    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/y;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_1

    :cond_61
    const/16 v0, 0xe

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "a"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "b"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "big"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "code"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, "em"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "font"

    aput-object v2, v0, v1

    const/4 v1, 0x6

    const-string v2, "i"

    aput-object v2, v0, v1

    const/4 v1, 0x7

    const-string v2, "nobr"

    aput-object v2, v0, v1

    const/16 v1, 0x8

    const-string v2, "s"

    aput-object v2, v0, v1

    const/16 v1, 0x9

    const-string v2, "small"

    aput-object v2, v0, v1

    const/16 v1, 0xa

    const-string v2, "strike"

    aput-object v2, v0, v1

    const/16 v1, 0xb

    const-string v2, "strong"

    aput-object v2, v0, v1

    const/16 v1, 0xc

    const-string v2, "tt"

    aput-object v2, v0, v1

    const/16 v1, 0xd

    const-string v2, "u"

    aput-object v2, v0, v1

    invoke-static {v7, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_73

    const/4 v0, 0x0

    move v6, v0

    :goto_9
    const/16 v0, 0x8

    if-ge v6, v0, :cond_0

    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v8

    if-nez v8, :cond_62

    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/y;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_1

    :cond_62
    invoke-virtual {p2, v8}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-nez v0, :cond_63

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2, v8}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    const/4 v0, 0x1

    goto/16 :goto_1

    :cond_63
    invoke-virtual {v8}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_64

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_64
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eq v0, v8, :cond_65

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_65
    const/4 v5, 0x0

    const/4 v2, 0x0

    const/4 v1, 0x0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i()Lcom/igexin/push/extension/distribution/basic/i/a/b;

    move-result-object v4

    const/4 v0, 0x0

    move v3, v0

    :goto_a
    invoke-virtual {v4}, Ljava/util/LinkedList;->size()I

    move-result v0

    if-ge v3, v0, :cond_67

    invoke-virtual {v4, v3}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-ne v0, v8, :cond_66

    add-int/lit8 v0, v3, -0x1

    invoke-virtual {v4, v0}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    const/4 v1, 0x1

    move v11, v1

    move-object v1, v0

    move v0, v11

    :goto_b
    add-int/lit8 v2, v3, 0x1

    move v3, v2

    move-object v2, v1

    move v1, v0

    goto :goto_a

    :cond_66
    if-eqz v1, :cond_78

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v9

    if-eqz v9, :cond_78

    move-object v5, v0

    :cond_67
    if-nez v5, :cond_68

    invoke-virtual {v8}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    invoke-virtual {p2, v8}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    const/4 v0, 0x1

    goto/16 :goto_1

    :cond_68
    const/4 v0, 0x0

    move v4, v0

    move-object v1, v5

    move-object v0, v5

    :goto_c
    const/4 v3, 0x3

    if-ge v4, v3, :cond_6b

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->d(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v3

    if-eqz v3, :cond_69

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    :cond_69
    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->l(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v3

    if-nez v3, :cond_6a

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-object v3, v0

    move-object v0, v1

    :goto_d
    add-int/lit8 v1, v4, 0x1

    move v4, v1

    move-object v1, v0

    move-object v0, v3

    goto :goto_c

    :cond_6a
    if-ne v0, v8, :cond_6d

    :cond_6b
    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const/4 v3, 0x5

    new-array v3, v3, [Ljava/lang/String;

    const/4 v4, 0x0

    const-string v9, "table"

    aput-object v9, v3, v4

    const/4 v4, 0x1

    const-string v9, "tbody"

    aput-object v9, v3, v4

    const/4 v4, 0x2

    const-string v9, "tfoot"

    aput-object v9, v3, v4

    const/4 v4, 0x3

    const-string v9, "thead"

    aput-object v9, v3, v4

    const/4 v4, 0x4

    const-string v9, "tr"

    aput-object v9, v3, v4

    invoke-static {v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_70

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_6c

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->A()V

    :cond_6c
    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    :goto_e
    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-static {v7}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;)V

    invoke-virtual {v5}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->y()Ljava/util/List;

    move-result-object v0

    invoke-virtual {v5}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->y()Ljava/util/List;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    new-array v1, v1, [Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-interface {v0, v1}, Ljava/util/List;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igexin/push/extension/distribution/basic/i/b/l;

    array-length v3, v0

    const/4 v1, 0x0

    :goto_f
    if-ge v1, v3, :cond_72

    aget-object v4, v0, v1

    invoke-virtual {v2, v4}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    add-int/lit8 v1, v1, 0x1

    goto :goto_f

    :cond_6d
    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v9

    invoke-static {v9}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v9

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f()Ljava/lang/String;

    move-result-object v10

    invoke-direct {v3, v9, v10}, Lcom/igexin/push/extension/distribution/basic/i/b/i;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;)V

    invoke-virtual {p2, v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    invoke-virtual {p2, v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    if-ne v1, v5, :cond_6e

    :cond_6e
    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_6f

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->A()V

    :cond_6f
    invoke-virtual {v3, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-object v0, v3

    goto/16 :goto_d

    :cond_70
    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_71

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->A()V

    :cond_71
    invoke-virtual {v2, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_e

    :cond_72
    invoke-virtual {v5, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {p2, v8}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->k(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    invoke-virtual {p2, v8}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    invoke-virtual {p2, v5, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    add-int/lit8 v0, v6, 0x1

    move v6, v0

    goto/16 :goto_9

    :cond_73
    const/4 v0, 0x3

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "applet"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "marquee"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "object"

    aput-object v2, v0, v1

    invoke-static {v7, v0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_76

    const-string v0, "name"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_74

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_74
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->s()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_75

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_75
    invoke-virtual {p2, v7}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->u()V

    goto/16 :goto_0

    :cond_76
    const-string v0, "br"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_77

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "br"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    const/4 v0, 0x0

    goto/16 :goto_1

    :cond_77
    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/y;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_1

    :cond_78
    move v0, v1

    move-object v1, v2

    goto/16 :goto_b

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_1
        :pswitch_2
        :pswitch_3
        :pswitch_4
        :pswitch_0
    .end packed-switch
.end method

.method b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 4

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i()Lcom/igexin/push/extension/distribution/basic/i/a/b;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/b;->descendingIterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_3

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_1
    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    :cond_2
    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_3
    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->i(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto :goto_0
.end method
