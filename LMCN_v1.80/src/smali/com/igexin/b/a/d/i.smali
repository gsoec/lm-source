.class final Lcom/igexin/b/a/d/i;
.super Ljava/lang/Thread;


# instance fields
.field volatile a:Z

.field b:Lcom/igexin/b/a/d/f;

.field final synthetic c:Lcom/igexin/b/a/d/e;


# direct methods
.method public constructor <init>(Lcom/igexin/b/a/d/e;)V
    .locals 1

    iput-object p1, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    invoke-direct {p0}, Ljava/lang/Thread;-><init>()V

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/d/i;->a:Z

    const-string v0, "taskService-processor"

    invoke-virtual {p0, v0}, Lcom/igexin/b/a/d/i;->setName(Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 11

    const/4 v10, 0x0

    const/4 v3, 0x0

    const/4 v1, 0x1

    const/4 v0, -0x2

    invoke-static {v0}, Landroid/os/Process;->setThreadPriority(I)V

    iget-object v0, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    iget-object v4, v0, Lcom/igexin/b/a/d/e;->k:Lcom/igexin/b/a/d/c;

    move v0, v1

    move-object v2, v3

    :goto_0
    iget-boolean v5, p0, Lcom/igexin/b/a/d/i;->a:Z

    if-eqz v5, :cond_c

    packed-switch v0, :pswitch_data_0

    goto :goto_0

    :pswitch_0
    :try_start_0
    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->d()V

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|TASK_INIT|initTask ="

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "@"

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isBlock = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->q()Z

    move-result v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isCycle = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->o:Z

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|doTime = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-wide v6, v2, Lcom/igexin/b/a/d/d;->u:J

    invoke-virtual {v0, v6, v7}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->q()Z

    move-result v0

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/d/i;->b:Lcom/igexin/b/a/d/f;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/b/a/d/f;

    iget-object v5, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    invoke-direct {v0, v5}, Lcom/igexin/b/a/d/f;-><init>(Lcom/igexin/b/a/d/e;)V

    iput-object v0, p0, Lcom/igexin/b/a/d/i;->b:Lcom/igexin/b/a/d/f;

    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, " is a block task!"

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/b/a/d/i;->b:Lcom/igexin/b/a/d/f;

    invoke-virtual {v0, v2}, Lcom/igexin/b/a/d/f;->a(Lcom/igexin/b/a/d/d;)V

    move v0, v1

    move-object v2, v3

    goto/16 :goto_0

    :cond_1
    iget-boolean v0, v2, Lcom/igexin/b/a/d/d;->o:Z

    if-eqz v0, :cond_2

    iget-wide v6, v2, Lcom/igexin/b/a/d/d;->u:J

    const-wide/16 v8, 0x0

    cmp-long v0, v6, v8

    if-nez v0, :cond_2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|"

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isBlock = false|cycyle = true|doTime = 0, "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "invalid ###########"

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move v0, v1

    goto/16 :goto_0

    :catch_0
    move-exception v0

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "TaskService|TASK_INIT|error|"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    move v0, v1

    goto/16 :goto_0

    :cond_2
    :pswitch_1
    :try_start_1
    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->a_()V

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->t()V

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->v()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    iget-object v0, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/e;->g()V

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|SERVICE_PROCESSING|finally|hasError = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->t:Z

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isDone = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->s()Z

    move-result v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isPending = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->p:Z

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isCycle = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->o:Z

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isBlcok = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->q()Z

    move-result v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-boolean v0, v2, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v0, :cond_3

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->c()V

    :cond_3
    iget-boolean v0, v2, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v0, :cond_4

    iget-boolean v0, v2, Lcom/igexin/b/a/d/d;->p:Z

    if-nez v0, :cond_4

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|SERVICE_PROCESSING|finally|mainQueue.offer task = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iput v10, v2, Lcom/igexin/b/a/d/d;->A:I

    invoke-virtual {v4, v2}, Lcom/igexin/b/a/d/c;->a(Lcom/igexin/b/a/d/d;)Z

    :cond_4
    move v0, v1

    move-object v2, v3

    :goto_1
    :pswitch_2
    :try_start_2
    invoke-virtual {v4}, Lcom/igexin/b/a/d/c;->c()Lcom/igexin/b/a/d/d;
    :try_end_2
    .catch Ljava/lang/InterruptedException; {:try_start_2 .. :try_end_2} :catch_2

    move-result-object v2

    :goto_2
    if-eqz v2, :cond_b

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v5, :cond_5

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->m:Z

    if-eqz v5, :cond_a

    :cond_5
    move-object v2, v3

    goto/16 :goto_0

    :catch_1
    move-exception v0

    :try_start_3
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "TaskService|SERVICE_PROCESSING|error|"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    const/4 v5, 0x1

    iput-boolean v5, v2, Lcom/igexin/b/a/d/d;->t:Z

    iput-object v0, v2, Lcom/igexin/b/a/d/d;->B:Ljava/lang/Exception;

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->w()V

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->p()V

    iget-object v0, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    iget-object v0, v0, Lcom/igexin/b/a/d/e;->j:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v0, v2}, Ljava/util/concurrent/ConcurrentLinkedQueue;->offer(Ljava/lang/Object;)Z
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    iget-object v0, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/e;->g()V

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|SERVICE_PROCESSING|finally|hasError = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->t:Z

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isDone = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->s()Z

    move-result v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isPending = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->p:Z

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isCycle = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v5, v2, Lcom/igexin/b/a/d/d;->o:Z

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v5, "|isBlcok = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->q()Z

    move-result v5

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-boolean v0, v2, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v0, :cond_6

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->c()V

    :cond_6
    iget-boolean v0, v2, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v0, :cond_7

    iget-boolean v0, v2, Lcom/igexin/b/a/d/d;->p:Z

    if-nez v0, :cond_7

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|SERVICE_PROCESSING|finally|mainQueue.offer task = "

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iput v10, v2, Lcom/igexin/b/a/d/d;->A:I

    invoke-virtual {v4, v2}, Lcom/igexin/b/a/d/c;->a(Lcom/igexin/b/a/d/d;)Z

    :cond_7
    move v0, v1

    move-object v2, v3

    goto/16 :goto_1

    :catchall_0
    move-exception v0

    iget-object v1, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    invoke-virtual {v1}, Lcom/igexin/b/a/d/e;->g()V

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "TaskService|SERVICE_PROCESSING|finally|hasError = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-boolean v3, v2, Lcom/igexin/b/a/d/d;->t:Z

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v3, "|isDone = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->s()Z

    move-result v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v3, "|isPending = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-boolean v3, v2, Lcom/igexin/b/a/d/d;->p:Z

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v3, "|isCycle = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-boolean v3, v2, Lcom/igexin/b/a/d/d;->o:Z

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v3, "|isBlcok = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->q()Z

    move-result v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-boolean v1, v2, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v1, :cond_8

    invoke-virtual {v2}, Lcom/igexin/b/a/d/d;->c()V

    :cond_8
    iget-boolean v1, v2, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v1, :cond_9

    iget-boolean v1, v2, Lcom/igexin/b/a/d/d;->p:Z

    if-nez v1, :cond_9

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "TaskService|SERVICE_PROCESSING|finally|mainQueue.offer task = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iput v10, v2, Lcom/igexin/b/a/d/d;->A:I

    invoke-virtual {v4, v2}, Lcom/igexin/b/a/d/c;->a(Lcom/igexin/b/a/d/d;)Z

    :cond_9
    throw v0

    :cond_a
    const/4 v0, -0x1

    goto/16 :goto_0

    :cond_b
    :pswitch_3
    move-object v0, v2

    iget-object v2, p0, Lcom/igexin/b/a/d/i;->c:Lcom/igexin/b/a/d/e;

    invoke-virtual {v2}, Lcom/igexin/b/a/d/e;->g()V

    move-object v2, v0

    move v0, v1

    goto/16 :goto_0

    :cond_c
    invoke-virtual {v4}, Lcom/igexin/b/a/d/c;->d()V

    return-void

    :catch_2
    move-exception v5

    goto/16 :goto_2

    nop

    :pswitch_data_0
    .packed-switch -0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
        :pswitch_3
    .end packed-switch
.end method
